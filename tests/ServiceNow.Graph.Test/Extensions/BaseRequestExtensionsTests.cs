using ServiceNow.Graph.Requests.Middleware.Options;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Test.Mocks;
using System.Net.Http;
using System;
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

            httpProvider = new HttpProvider(domain, serializer.Object);
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
    }
}
