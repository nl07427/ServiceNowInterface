﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Test.TestModels;
using ServiceNow.Graph.Test.TestModels.ServiceModels;
using Xunit;

namespace ServiceNow.Graph.Test.Serialization
{
    public class SerializerTests
    {
        private Serializer serializer;

        public SerializerTests()
        {
            this.serializer = new Serializer();
        }

        [Fact]
        public void AbstractClassDeserializationFailure()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";
            ServiceException exception = Assert.Throws<ServiceException>(() => this.serializer.DeserializeObject<AbstractClass>(stringToDeserialize));

            Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
            Assert.Equal(
                string.Format(ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString, typeof(AbstractClass).FullName),
                exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public void DeserializeDerivedType()
        {
            var id = "id";
            var name = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"#microsoft.graph.dotnetCore.core.test.testModels.derivedTypeClass\", \"name\":\"{1}\"}}",
                id,
                name);

            var derivedType = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.NotNull(derivedType);
            Assert.Equal(id, derivedType.Id);
            Assert.Equal(name, derivedType.Name);
        }

        [Fact]
        public void DerivedTypeConverterFollowsNamingProperty()
        {
            var id = "id";
            var givenName = "name";
            var link = "localhost.com"; // this property name does not match the object name

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"givenName\":\"{1}\", \"link\":\"{2}\"}}",
                id,
                givenName,
                link);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.NotNull(instance);
            Assert.Equal(id, instance.Id);
            Assert.Equal(link, instance.WebUrl);
            Assert.NotNull(instance.AdditionalData);
            Assert.Equal(givenName, instance.AdditionalData["givenName"].ToString());
        }

        [Fact]
        public void DeserializeStream()
        {
            var id = "id";

            var stringToDeserialize = string.Format("{{\"id\":\"{0}\"}}", id);

            using (var serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize)))
            {
                var instance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedStream);

                Assert.NotNull(instance);
                Assert.Equal(id, instance.Id);
                Assert.Null(instance.AdditionalData);
            }
        }

        [Fact]
        public void DeserializeEmptyStringOrStream()
        {
            var stringToDeserialize = string.Empty;

            // Asset empty stream deserializes to null
            using (var serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize)))
            {
                var instance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedStream);
                Assert.Null(instance);
            }

            // Asset empty string deserializes to null
            var stringInstance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);
            Assert.Null(stringInstance);
        }

        [Fact]
        public void DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var id = "id";

            var stringToDeserialize = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                enumValue,
                id);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.NotNull(instance);
            Assert.Equal(id, instance.Id);
            Assert.Null(instance.EnumType);
            Assert.NotNull(instance.AdditionalData);
            Assert.Equal(enumValue, instance.AdditionalData["enumType"].ToString());
        }

        [Fact]
        public void DerivedTypeWithoutDefaultConstructor()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";
            ServiceException exception = Assert.Throws<ServiceException>(() => this.serializer.DeserializeObject<NoDefaultConstructor>(stringToDeserialize));

            Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
            Assert.Equal(
                string.Format(
                    ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString,
                    typeof(NoDefaultConstructor).AssemblyQualifiedName),
                exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public void SerializeAndDeserializeCollectionPage()
        {
            var collectionPage = new CollectionPageInstance
            {
                new DerivedTypeClass { Id = "id" },
                new DerivedTypeClass { Id = "id1" },
                new DerivedTypeClass { Id = "id2" },
                new DerivedTypeClass { Id = "id3" },

            };

            var serializedString = this.serializer.SerializeObject(collectionPage);

            var deserializedPage = this.serializer.DeserializeObject<CollectionPageInstance>(serializedString);
            Assert.IsType<CollectionPageInstance>(deserializedPage);
            Assert.Equal(4, deserializedPage.Count);
            Assert.Equal("id", deserializedPage[0].Id);
            Assert.Equal("id1", deserializedPage[1].Id);
            Assert.Equal("id2", deserializedPage[2].Id);
            Assert.Equal("id3", deserializedPage[3].Id);
        }
        
        [Fact]
        public void SerializeAndDeserializeKnownEnumValue()
        {
            var instance = new DerivedTypeClass
            {
                Id = "id",
                EnumType = EnumType.Value,
            };

            var expectedSerializedStream = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                "value",
                instance.Id);

            var serializedValue = this.serializer.SerializeObject(instance);

            Assert.Equal(expectedSerializedStream, serializedValue);

            var newInstance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedValue);

            Assert.NotNull(newInstance);
            Assert.Equal(instance.Id, instance.Id);
            Assert.Equal(EnumType.Value, instance.EnumType);
            Assert.Null(instance.AdditionalData);
        }

        [Fact]
        public void SerializeEnumValueWithFlags()
        {
            EnumTypeWithFlags enumValueWithFlags = EnumTypeWithFlags.FirstValue | EnumTypeWithFlags.SecondValue;

            var expectedSerializedValue = "\"firstValue, secondValue\""; // All values should be camelCased

            var serializedValue = this.serializer.SerializeObject(enumValueWithFlags);

            Assert.Equal(expectedSerializedValue, serializedValue);
        }

        [Fact]
        public void DerivedTypeConverterIgnoresPropertyWithJsonIgnore()
        {

            var date = new DerivedTypeClass
            {
                Name = "name",
                IgnoredNumber = 230 // we shouldn't see this value
            };

            var expectedSerializedString = string.Format("{{\"name\":\"{0}\"}}", date.Name);

            var serializedString = this.serializer.SerializeObject(date);

            Assert.Equal(expectedSerializedString, serializedString);
        }

        [Fact]
        public void SerializeObjectWithAdditionalDataWithDerivedTypeConverter()
        {
            // This example class uses the derived type converter
            // Arrange
            TestItemBody testItemBody = new TestItemBody
            {
                Content = "Example Content",
                ContentType = EnumTypeWithFlags.FirstValue,
                AdditionalData = new Dictionary<string, object>
                {
                    { "length" , "100" },
                    { "extraProperty", null }
                }
            };
            var expectedSerializedString = "{" +
                                               "\"contentType\":\"firstValue\"," +
                                               "\"content\":\"Example Content\"," +
                                               "\"@odata.type\":\"microsoft.graph.itemBody\"," +
                                               "\"length\":\"100\"," + // should be at the same level as other properties
                                               "\"extraProperty\":null" +
                                           "}";

            // Act
            var serializedString = this.serializer.SerializeObject(testItemBody);

            //Assert
            Assert.Equal(expectedSerializedString, serializedString);
        }

        [Fact]
        public void SerializeInterfaceProperty()
        {
            // Arrange
            var user = new TestUser()
            {
                EventDeltas = new TestEventDeltaCollectionPage()
                {
                    new TestEvent() { Id = "id" }

                }
            };
            var expectedSerializedString = "{\"@odata.type\":\"microsoft.graph.user\",\"eventDeltas\":[{\"id\":\"id\",\"@odata.type\":\"microsoft.graph.event\"}]}";

            // Act
            var serializedString = this.serializer.SerializeObject(user);

            // Assert that the interface properties respect the json serializer options
            Assert.Equal(expectedSerializedString, serializedString);
        }
    }
}
