using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Exceptions;
using System;
using Xunit;

namespace ServiceNow.Graph.Test.Authentication
{
    public class ClientCredentialProviderTests
    {
        [Fact]
        public async void AuthenticateRequestWithClosedPortThrowsException()
        {
            string domain = "127.0.0.1";
            string clientId = "00000000-0000-0000-0000-000000000000";
            string clientSecret = "00000000-0000-0000-0000-000000000000";
            string username = "user";
            string password = "password";

            ClientCredentialProvider credentialProvider = new ClientCredentialProvider(domain, clientId, clientSecret, username, password);

            AuthenticationException ex = await Assert.ThrowsAsync<AuthenticationException>(() => credentialProvider.AuthenticateRequestAsync(null));
        }
    }
}
