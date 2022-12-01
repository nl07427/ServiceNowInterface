using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ServiceNow.Graph.Authentication;
using Xunit;

namespace ServiceNow.Graph.Test.Authentication
{
    public class DelegateAuthenticationProviderTests
    {
        [Fact]
        public async Task AppendAuthenticationHeaderAsync()
        {
            var authenticationToken = "token";

            var authenticationProvider = new DelegateAuthenticationProvider(
                (requestMessage) =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Constants.Headers.Bearer, authenticationToken);
                    return Task.FromResult(0);
                });

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await authenticationProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.Equal(
                    string.Format("{0} {1}", Constants.Headers.Bearer, authenticationToken),
                    httpRequestMessage.Headers.Authorization.ToString());
            }
        }

        [Fact]
        public async Task AppendAuthenticationHeaderAsync_DelegateNotSet()
        {
            var authenticationProvider = new DelegateAuthenticationProvider(null);

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await authenticationProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.Null(httpRequestMessage.Headers.Authorization);
            }
        }
    }
}
