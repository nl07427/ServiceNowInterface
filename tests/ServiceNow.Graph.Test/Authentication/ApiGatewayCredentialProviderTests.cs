using System.Linq;
using System.Net.Http;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Exceptions;
using Xunit;

namespace ServiceNow.Graph.Test.Authentication
{
    public class ApiGatewayCredentialProviderTests
    {
        [Fact]
        public async void AppendAuthenticationHeaderAsync()
        {
            string clientId = "00000000-0000-0000-0000-000000000000";
            string clientSecret = "00000000-0000-0000-0000-000000000000";
            ApiGatewayCredentialProvider credentialProvider = new ApiGatewayCredentialProvider(clientId, clientSecret);

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await credentialProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.Equal(clientId, httpRequestMessage.Headers.GetValues(Constants.Headers.ApiGatewayClientId).FirstOrDefault());
                Assert.Equal(clientSecret, httpRequestMessage.Headers.GetValues(Constants.Headers.ApiGatewayClientSecret).FirstOrDefault());
                Assert.Equal("*/*", httpRequestMessage.Headers.GetValues(Constants.Headers.Accept).FirstOrDefault());
            }
        }
    }
}
