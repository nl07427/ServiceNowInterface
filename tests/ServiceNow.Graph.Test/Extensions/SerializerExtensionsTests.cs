using System.Net.Http;
using System.Threading.Tasks;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Extensions;
using Xunit;
using ServiceNow.Graph.Test.TestModels;

namespace ServiceNow.Graph.Test.Extensions
{
    public class SerializerExtensionsTests
    {
        [Fact]
        public async Task SerializeAsJsonContent_SerializesStringObject()
        {
            Serializer serializer = new Serializer();
            string objectToSerialize = "Hello World";
            string expectedJsonSerializedContent = "Hello World";

            HttpContent jsonSerializedContent = serializer.SerializeAsJsonContent(objectToSerialize);
            Assert.Equal(expectedJsonSerializedContent, await jsonSerializedContent.ReadAsStringAsync());
        }

        [Fact]
        public async Task SerializeAsJsonContent_SerializesCustomObject()
        {
            Serializer serializer = new Serializer();
            var objectToSerialize = new DerivedTypeClass
            {
                Id = "id",
                EnumType = EnumType.Value,
            };
            
            var expectedJsonSerializedContent = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                "value",
                objectToSerialize.Id);

            HttpContent jsonSerializedContent = serializer.SerializeAsJsonContent(objectToSerialize);
            Assert.Equal(expectedJsonSerializedContent, await jsonSerializedContent.ReadAsStringAsync());
        }
    }
}
