using ServiceNow.Graph.Serialization;
using Moq;

namespace ServiceNow.Graph.Test.Mocks
{
    public class MockSerializer : Mock<ISerializer>
    {
        public MockSerializer()
            : base(MockBehavior.Strict)
        {
            this.Setup(
                provider => provider.SerializeObject(It.IsAny<object>()))
                .Returns("{\"key\": \"value\"}");
        }
    }
}
