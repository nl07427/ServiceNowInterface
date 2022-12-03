using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Test.Mocks
{
    public class MockHttpProvider : Mock<IHttpProvider>
    {
        public MockHttpProvider(HttpResponseMessage httpResponseMessage, ISerializer serializer = null)
            : base(MockBehavior.Strict)
        {
            this.Setup(
                provider => provider.SendAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(httpResponseMessage));

            this.SetupGet(provider => provider.Serializer).Returns(serializer);
        }
    }
}
