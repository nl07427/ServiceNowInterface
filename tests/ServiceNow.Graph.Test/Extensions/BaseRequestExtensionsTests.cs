using ServiceNow.Graph.Requests.Middleware.Options;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Test.Mocks;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ServiceNow.Graph.Test.Extensions
{
    public class BaseRequestExtensionsTests : IDisposable
    {
        private const string domain = "https://localhost/v1.0";
        private const string requestUrl = "http://foo.bar";
        private const string defaultAuthHeader = "Default-token";
        private HttpProvider httpProvider;
        private BaseClient baseClient;
        private MockSerializer serializer = new MockSerializer();
        private TestHttpMessageHandler testHttpMessageHandler;
        private MockAuthenticationProvider defaultAuthProvider;

        public BaseRequestExtensionsTests()
        {
            defaultAuthProvider = new MockAuthenticationProvider(defaultAuthHeader);
            testHttpMessageHandler = new TestHttpMessageHandler();

            var defaultHandlers = ServiceNowClientFactory.CreateDefaultHandlers(defaultAuthProvider.Object);
            var pipeline = ServiceNowClientFactory.CreatePipeline(defaultHandlers, this.testHttpMessageHandler);

            httpProvider = new HttpProvider(pipeline, true, domain, serializer.Object);
            baseClient = new BaseClient(domain, defaultAuthProvider.Object, httpProvider);
        }

        public void Dispose()
        {
            httpProvider.Dispose();
        }

        [Fact]
        public void WithShouldRetry_ShouldDelegateToRetryOption()
        {
            using (HttpResponseMessage httpResponseMessage = new HttpResponseMessage())
            {
                int delay = 1;
                int attempt = 1;
                var baseRequest = new BaseRequest(requestUrl, baseClient);
                baseRequest.WithShouldRetry((d, a, r) => false);

                Assert.IsType<ServiceNowRequestContext>(baseRequest.GetHttpRequestMessage().Properties[typeof(ServiceNowRequestContext).ToString()]);
                Assert.False(baseRequest.GetHttpRequestMessage().GetMiddlewareOption<RetryHandlerOption>().ShouldRetry(delay, attempt, httpResponseMessage));
            }
        }

        [Fact]
        public void WithMaxRetry_ShouldAddMaxRetryToRetryOption()
        {
            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.WithMaxRetry(3);

            Assert.IsType<ServiceNowRequestContext>(baseRequest.GetHttpRequestMessage().Properties[typeof(ServiceNowRequestContext).ToString()]);
            Assert.Equal(3, baseRequest.GetHttpRequestMessage().GetMiddlewareOption<RetryHandlerOption>().MaxRetry);
        }

        [Fact]
        public void WithMaxRedirects_ShouldAddMaxRedirectsToRedirectOption()
        {
            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.WithMaxRedirects(4);

            Assert.IsType<ServiceNowRequestContext>(baseRequest.GetHttpRequestMessage().Properties[typeof(ServiceNowRequestContext).ToString()]);
            Assert.Equal(4, baseRequest.GetHttpRequestMessage().GetMiddlewareOption<RedirectHandlerOption>().MaxRedirect);
        }

        [Fact]
        public void WithResponseHandler_ShouldAddResponseHandler()
        {
            var baseRequest = new BaseRequest(requestUrl, baseClient);
            var newResponseHandler = new ResponseHandler(serializer.Object);
            baseRequest.WithResponseHandler(newResponseHandler);

            Assert.Same(newResponseHandler, baseRequest.ResponseHandler);
        }

        [Fact]
        public void WithPerRequestAuthProvider_ShouldAddPerRequestAuthProviderToAuthHandlerOption()
        {
            var requestMockAuthProvider = new MockAuthenticationProvider("PerRequest-Token");

            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.Client.PerRequestAuthProvider = () => requestMockAuthProvider.Object;
            baseRequest.WithPerRequestAuthProvider();
            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.IsType<ServiceNowRequestContext>(baseRequest.GetHttpRequestMessage().Properties[typeof(ServiceNowRequestContext).ToString()]);
            Assert.NotSame(baseClient.AuthenticationProvider, httpRequestMessage.GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider);
            Assert.Same(requestMockAuthProvider.Object, httpRequestMessage.GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider);
        }

        [Fact]
        public async Task WithPerRequestAuthProvider_ShouldUsePerRequestAuthProviderAsync()
        {
            string authorizationHeader = "PerRequest-Token";
            var requestMockAuthProvider = new MockAuthenticationProvider(authorizationHeader);

            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.Client.PerRequestAuthProvider = () => requestMockAuthProvider.Object;
            baseRequest.WithPerRequestAuthProvider();

            using (var httpResponseMessage = new HttpResponseMessage())
            {
                var httpRequestMessage = baseRequest.GetHttpRequestMessage();
                testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                var returnedResponseMessage = await httpProvider.SendAsync(httpRequestMessage);

                Assert.Equal(httpResponseMessage, returnedResponseMessage);
                Assert.Equal(authorizationHeader, returnedResponseMessage.RequestMessage.Headers.Authorization.Parameter);
            }
        }

        [Fact]
        public async Task WithPerRequestAuthProvider_ShouldUseDefaultAuthProviderAsync()
        {
            string perRequestAutHeader = "PerRequest-Token";
            var requestMockAuthProvider = new MockAuthenticationProvider(perRequestAutHeader);

            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.Client.PerRequestAuthProvider = () => requestMockAuthProvider.Object;

            using (var httpResponseMessage = new HttpResponseMessage())
            {
                var httpRequestMessage = baseRequest.GetHttpRequestMessage();
                testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                var returnedResponseMessage = await httpProvider.SendAsync(httpRequestMessage);

                Assert.Equal(httpResponseMessage, returnedResponseMessage);
                Assert.NotEqual(perRequestAutHeader, returnedResponseMessage.RequestMessage.Headers.Authorization.Parameter);
                Assert.Equal(defaultAuthHeader, returnedResponseMessage.RequestMessage.Headers.Authorization.Parameter);
            }
        }

        [Fact]
        public async Task WithDefaultAuthProvider_ShouldUseDefaultAuthProviderAsync()
        {
            string perRequestAutHeader = "PerRequest-Token";
            var requestMockAuthProvider = new MockAuthenticationProvider(perRequestAutHeader);

            var baseRequest = new BaseRequest(requestUrl, baseClient);
            baseRequest.Client.PerRequestAuthProvider = () => requestMockAuthProvider.Object;
            baseRequest.WithDefaultAuthProvider();
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                var httpRequestMessage = baseRequest.GetHttpRequestMessage();
                testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                var returnedResponseMessage = await httpProvider.SendAsync(httpRequestMessage);

                Assert.Equal(httpResponseMessage, returnedResponseMessage);
                Assert.NotEqual(perRequestAutHeader, returnedResponseMessage.RequestMessage.Headers.Authorization.Parameter);
                Assert.Equal(defaultAuthHeader, returnedResponseMessage.RequestMessage.Headers.Authorization.Parameter);
            }
        }
    }
}
