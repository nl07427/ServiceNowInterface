using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Test.TestModels;
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
    }
}
