using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Test.Mocks;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class SimpleHttpProviderTests : IDisposable
    {
        private SimpleHttpProvider simpleHttpProvider;
        private readonly MockSerializer serializer;
        private readonly TestHttpMessageHandler testHttpMessageHandler;
        private readonly MockAuthenticationProvider authProvider;
        private readonly string domain = "127.0.0.1";

        /*
         {
            "error": {
                "code": "BadRequest",
                "message": "Resource not found for the segment 'mer'.",
                "innerError": {
                    "request - id": "a9acfc00-2b19-44b5-a2c6-6c329b4337b3",
                    "date": "2019-09-10T18:26:26",
                    "code": "inner-error-code"
                },
                "target": "target-value",
                "unexpected-property": "unexpected-property-value",
                "details": [
                    {
                        "code": "details-code-value",
                        "message": "details",
                        "target": "details-target-value",
                        "unexpected-details-property": "unexpected-details-property-value"
                    },
                    {
                        "code": "details-code-value2"
                    }
                ]
            }
        }
        */
        
        private const string JsonErrorResponseBody = "{\"error\":{\"code\":\"BadRequest\",\"message\":\"Resource not found for the segment 'mer'.\",\"innerError\":{\"request - id\":\"a9acfc00-2b19-44b5-a2c6-6c329b4337b3\",\"date\":\"2019-09-10T18:26:26\",\"code\":\"inner-error-code\"},\"target\":\"target-value\",\"unexpected-property\":\"unexpected-property-value\",\"details\":[{\"code\":\"details-code-value\",\"message\":\"details\",\"target\":\"details-target-value\",\"unexpected-details-property\":\"unexpected-details-property-value\"},{\"code\":\"details-code-value2\"}]}}";

        public SimpleHttpProviderTests()
        {
            this.testHttpMessageHandler = new TestHttpMessageHandler();
            this.authProvider = new MockAuthenticationProvider();
            this.serializer = new MockSerializer();

            var defaultHandlers = ServiceNowClientFactory.CreateDefaultHandlers(authProvider.Object);
            var httpClient = ServiceNowClientFactory.Create(handlers: defaultHandlers, domain: this.domain, finalHandler: testHttpMessageHandler);

            this.simpleHttpProvider = new SimpleHttpProvider(httpClient, this.domain, this.serializer.Object);
        }

        public void Dispose()
        {
            this.simpleHttpProvider.Dispose();
        }

        [Fact]
        public void InitSuccessfullyWithoutHttpClient()
        {
            // Create a provider using a null client
            SimpleHttpProvider testSimpleHttpProvider = new SimpleHttpProvider(null, this.domain, this.serializer.Object);
            // Assert that the httpclient is set (from the factory)
            Assert.NotNull(testSimpleHttpProvider.HttpClient);
        }

        [Fact]
        public async Task InitSuccessfullyWithUsedHttpClient()
        {
            // Create a httpClient
            var defaultHandlers = ServiceNowClientFactory.CreateDefaultHandlers(authProvider.Object);
            using (HttpClient httpClient = ServiceNowClientFactory.Create(handlers: defaultHandlers, domain: this.domain, finalHandler: testHttpMessageHandler))
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                // use the httpClient to send something out
                await httpClient.SendAsync(httpRequestMessage);
                // Create a provider using the same client
                SimpleHttpProvider testSimpleHttpProvider = new SimpleHttpProvider(httpClient, this.domain, this.serializer.Object);
                // Assert that using the used client throws no errors on initialization
                Assert.NotNull(testSimpleHttpProvider.Serializer);
                Assert.Equal(httpClient.Timeout, simpleHttpProvider.OverallTimeout);
            }
        }

        [Fact]
        public async Task SendAsync()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                var returnedResponseMessage = await this.simpleHttpProvider.SendAsync(httpRequestMessage);
                Assert.True(returnedResponseMessage.RequestMessage.Headers.Contains(Constants.Headers.FeatureFlag));
                Assert.Equal(httpResponseMessage, returnedResponseMessage);
            }
        }


        [Fact]
        public async Task SendAsync_ThrowsClientGeneralException()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.simpleHttpProvider.Dispose();
                var clientException = new Exception();

                var defaultHandlers = ServiceNowClientFactory.CreateDefaultHandlers(authProvider.Object);
                var httpClient = ServiceNowClientFactory.Create(handlers: defaultHandlers, domain: this.domain, finalHandler: new ExceptionHttpMessageHandler(clientException));
                this.simpleHttpProvider = new SimpleHttpProvider(httpClient, this.domain, this.serializer.Object);

                ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await this.simpleHttpProvider.SendAsync(
                    httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None));

                Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
                Assert.Equal(ErrorConstants.Messages.UnexpectedExceptionOnSend, exception.Error.ErrorDetail.DetailedMessage);
                Assert.Equal(clientException, exception.InnerException);
            }
        }
    }
}
