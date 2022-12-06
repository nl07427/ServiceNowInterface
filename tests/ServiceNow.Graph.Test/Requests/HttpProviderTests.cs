using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Test.Mocks;
using Xunit;
using ServiceNow.Graph.Requests.Middleware.Options;

namespace ServiceNow.Graph.Test.Requests
{
    public class HttpProviderTests : IDisposable
    {
        private HttpProvider httpProvider;
        private MockSerializer serializer = new MockSerializer();
        private TestHttpMessageHandler testHttpMessageHandler;
        private MockAuthenticationProvider authProvider;
        private string domain = "127.0.0.1";
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
        
        private const string jsonErrorResponseBody = "{\"error\":{\"code\":\"BadRequest\",\"message\":\"Resource not found for the segment 'mer'.\",\"innerError\":{\"request - id\":\"a9acfc00-2b19-44b5-a2c6-6c329b4337b3\",\"date\":\"2019-09-10T18:26:26\",\"code\":\"inner-error-code\"},\"target\":\"target-value\",\"unexpected-property\":\"unexpected-property-value\",\"details\":[{\"code\":\"details-code-value\",\"message\":\"details\",\"target\":\"details-target-value\",\"unexpected-details-property\":\"unexpected-details-property-value\"},{\"code\":\"details-code-value2\"}]}}";

        public HttpProviderTests()
        {
            this.testHttpMessageHandler = new TestHttpMessageHandler();
            this.authProvider = new MockAuthenticationProvider();

            var defaultHandlers = ServiceNowClientFactory.CreateDefaultHandlers(authProvider.Object);
            var pipeline = ServiceNowClientFactory.CreatePipeline(defaultHandlers, this.testHttpMessageHandler);

            this.httpProvider = new HttpProvider(pipeline, true, domain, this.serializer.Object);
        }

        public void Dispose()
        {
            this.httpProvider.Dispose();
        }

        [Fact]
        public void HttpProvider_CustomCacheHeaderAndTimeout()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var cacheHeader = new CacheControlHeaderValue();
            using (var defaultHttpProvider = new HttpProvider(domain, null) { CacheControlHeader = cacheHeader, OverallTimeout = timeout })
            {
                Assert.False(defaultHttpProvider.HttpClient.DefaultRequestHeaders.CacheControl.NoCache);
                Assert.False(defaultHttpProvider.HttpClient.DefaultRequestHeaders.CacheControl.NoStore);
                Assert.True(defaultHttpProvider.HttpClient.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
                Assert.Equal(timeout, defaultHttpProvider.HttpClient.Timeout);
                Assert.NotNull(defaultHttpProvider.Serializer);
                Assert.IsType<Serializer>(defaultHttpProvider.Serializer);
            }
        }

        [Fact]
        public void HttpProvider_CustomHttpClientHandler()
        {
            using (var httpClientHandler = new HttpClientHandler())
            using (var httpProvider = new HttpProvider(httpClientHandler, false, null))
            {
                Assert.Equal(httpClientHandler, httpProvider.HttpMessageHandler);
                Assert.True(httpProvider.HttpClient.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
                Assert.False(httpProvider.DisposeHandler);
            }
        }

        [Fact]
        public void HttpProvider_DefaultConstructor()
        {
            using (var defaultHttpProvider = new HttpProvider(domain))
            {
                Assert.True(defaultHttpProvider.HttpClient.DefaultRequestHeaders.CacheControl.NoCache);
                Assert.True(defaultHttpProvider.HttpClient.DefaultRequestHeaders.CacheControl.NoStore);
                Assert.True(defaultHttpProvider.HttpClient.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
                Assert.True(defaultHttpProvider.DisposeHandler);
                Assert.NotNull(defaultHttpProvider.HttpMessageHandler);
                Assert.Equal(TimeSpan.FromMinutes(15), defaultHttpProvider.HttpClient.Timeout);
                Assert.IsType<Serializer>(defaultHttpProvider.Serializer);

                Assert.IsType<HttpClientHandler>(defaultHttpProvider.HttpMessageHandler);
                Assert.False((defaultHttpProvider.HttpMessageHandler as HttpClientHandler).AllowAutoRedirect);
            }
        }

        [Fact]
        public void HttpProvider_HttpMessageHandlerConstructor()
        {

            using (var httpProvider = new HttpProvider(this.testHttpMessageHandler, false, null))
            {
                Assert.NotNull(httpProvider.HttpMessageHandler);
                Assert.True(httpProvider.HttpClient.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
                Assert.Equal(httpProvider.HttpMessageHandler, this.testHttpMessageHandler);
                Assert.False(httpProvider.DisposeHandler);
                Assert.IsType<Serializer>(httpProvider.Serializer);
            }
        }

        [Fact]
        public async Task SendAsync()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                this.AddGraphRequestContextToRequest(httpRequestMessage);
                var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);
                Assert.True(returnedResponseMessage.RequestMessage.Headers.Contains(Constants.Headers.FeatureFlag));
                Assert.Equal(httpResponseMessage, returnedResponseMessage);
            }
        }

        [Fact]
        public async Task SendAsync_ClientGeneralException()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.httpProvider.Dispose();

                var clientException = new Exception();
                this.httpProvider = new HttpProvider(new ExceptionHttpMessageHandler(clientException), /* disposeHandler */ true, null);
                this.AddGraphRequestContextToRequest(httpRequestMessage);

                ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendRequestAsync(
                    httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None));

                Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
                Assert.Equal(ErrorConstants.Messages.UnexpectedExceptionOnSend, exception.Error.ErrorDetail.DetailedMessage);
                Assert.Equal(clientException, exception.InnerException);
            }
        }

        [Fact]
        public async Task SendAsync_InvalidRedirectResponse()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.StatusCode = HttpStatusCode.Redirect;
                httpResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                this.AddGraphRequestContextToRequest(httpRequestMessage);

                ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
                Assert.Equal(
                    ErrorConstants.Messages.LocationHeaderNotSetOnRedirect,
                    exception.Error.ErrorDetail.DetailedMessage);
            }
        }

        private void AddGraphRequestContextToRequest(HttpRequestMessage httpRequestMessage)
        {
            var requestContext = new ServiceNowRequestContext
            {
                MiddlewareOptions = new Dictionary<string, IMiddlewareOption>() {
                    {
                        nameof(AuthenticationHandlerOption),
                        new AuthenticationHandlerOption { AuthenticationProvider = authProvider .Object }
                    }
                },
                ClientRequestId = "client-request-id"
            };
            httpRequestMessage.Properties.Add(nameof(ServiceNowRequestContext), requestContext);
        }
    }
}
