using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Test.Mocks;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class BaseClientTests
    {
        private MockAuthenticationProvider authenticationProvider;
        
        public BaseClientTests()
        {
            this.authenticationProvider = new MockAuthenticationProvider();
        }

        [Fact]
        public void BaseClient_InitializeBaseUrlWithoutTrailingSlash()
        {
            var expectedBaseUrl = "https://localhost";

            var baseClient = new BaseClient(expectedBaseUrl, this.authenticationProvider.Object);

            Assert.Equal(expectedBaseUrl, baseClient.Domain);
        }

        [Fact]
        public void BaseClient_InitializeBaseUrlWithTrailingSlash()
        {
            var expectedBaseUrl = "https://localhost";

            var baseClient = new BaseClient("https://localhost/", this.authenticationProvider.Object);

            Assert.Equal(expectedBaseUrl, baseClient.Domain);
        }

        [Fact]
        public void BaseClient_InitializeEmptyBaseUrl()
        {
            ServiceException exception = Assert.Throws<ServiceException>(() => new BaseClient(null, this.authenticationProvider.Object));
            Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.BaseUrlMissing, exception.Error.ErrorDetail.DetailedMessage);
        }
    }
}
