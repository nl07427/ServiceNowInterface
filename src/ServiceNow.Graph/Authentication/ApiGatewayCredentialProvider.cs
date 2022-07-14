using System.Net.Http;

namespace ServiceNow.Graph.Authentication
{
    /// <summary>
    /// An <see cref="IAuthenticationProvider"/>
    /// Adds the IBM DataPower authentication header pair to the request
    /// </summary>
    public class ApiGatewayCredentialProvider : IAuthenticationProvider
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        /// <summary>
        /// Creates the ServiceNow hybrid client credential provider
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <param name="clientSecret">Client secret</param>
        public ApiGatewayCredentialProvider(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <summary>
        /// Adds the required IBM DataPower authentication headers to the request.
        /// </summary>
        /// <param name="httpRequestMessage">A <see cref="HttpRequestMessage"/> to authenticate</param>
        public async System.Threading.Tasks.Task AuthenticateRequestAsync(HttpRequestMessage httpRequestMessage)
        {
            await System.Threading.Tasks.Task.CompletedTask;
            httpRequestMessage.Headers.Add(Constants.Headers.ApiGatewayClientId, _clientId);
            httpRequestMessage.Headers.Add(Constants.Headers.ApiGatewayClientSecret, _clientSecret);
            httpRequestMessage.Headers.Add(Constants.Headers.Accept, "*/*");
        }
    }
}
