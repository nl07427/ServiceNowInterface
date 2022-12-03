using ServiceNow.Graph.Authentication;
using Moq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Test.Mocks
{
    public class MockAuthenticationProvider : Mock<IAuthenticationProvider>
    {
        public MockAuthenticationProvider(string accessToken = null)
            : base(MockBehavior.Strict)
        {
            this.Setup(
                provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(r => r.Headers.Authorization = new AuthenticationHeaderValue(Constants.Headers.Bearer, accessToken ?? "Default-Token"))
                .Returns(Task.FromResult(0));
        }
    }
}
