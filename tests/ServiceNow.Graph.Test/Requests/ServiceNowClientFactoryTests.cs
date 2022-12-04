using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Requests.Middleware;
using ServiceNow.Graph.Test.Mocks;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class GraphClientFactoryTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private DelegatingHandler[] handlers;
        private const string expectedAccessToken = "service-now-client-factory-infused-token";
        private MockAuthenticationProvider testAuthenticationProvider;
        private string domain = "127.0.0.1";

        public GraphClientFactoryTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            testAuthenticationProvider = new MockAuthenticationProvider(expectedAccessToken);
            handlers = ServiceNowClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object).ToArray();
        }

        public void Dispose()
        {
            this.testHttpMessageHandler.Dispose();
        }

        // Note:
        // 1. Xunit's IsType doesn't consider inheritance behind the classes.
        // 2. We can't control the order of execution for the tests
        // and 'ServiceNowClientFactory.DefaultHttpHandler' can easily be modified
        // by other tests since it's a static delegate.

#if iOS || macOS
        [Fact]
        public void Should_CreatePipeline_Without_CompressionHandler()
        {
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)ServiceNowClientFactory.CreatePipeline(handlers))
            using (RetryHandler retryHandler = (RetryHandler)authenticationHandler.InnerHandler)
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
#if iOS
            using (NSUrlSessionHandler innerMost = (NSUrlSessionHandler)redirectHandler.InnerHandler)
#elif macOS
            using (Foundation.NSUrlSessionHandler innerMost = (Foundation.NSUrlSessionHandler)redirectHandler.InnerHandler)
#endif
            {
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(innerMost);
                Assert.IsType<AuthenticationHandler>(authenticationHandler);
                Assert.IsType<RetryHandler>(retryHandler);
                Assert.IsType<RedirectHandler>(redirectHandler);
#if iOS
                Assert.IsType<NSUrlSessionHandler>(innerMost);
#elif macOS
                Assert.IsType<Foundation.NSUrlSessionHandler>(innerMost);
#endif
            }
        }
#else
        [Fact]
        public void Should_CreatePipeline_Without_HttpMessageHandlerInput()
        {
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)ServiceNowClientFactory.CreatePipeline(handlers))
            using (CompressionHandler compressionHandler = (CompressionHandler)authenticationHandler.InnerHandler)
            using (RetryHandler retryHandler = (RetryHandler)compressionHandler.InnerHandler)
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (HttpMessageHandler innerMost = redirectHandler.InnerHandler)
            {
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(compressionHandler);
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(innerMost);
                Assert.IsType<AuthenticationHandler>(authenticationHandler);
                Assert.IsType<CompressionHandler>(compressionHandler);
                Assert.IsType<RetryHandler>(retryHandler);
                Assert.IsType<RedirectHandler>(redirectHandler);
                Assert.True(innerMost is HttpMessageHandler);
            }
        }
#endif
        [Fact]
        public void CreatePipelineWithHttpMessageHandlerInput()
        {
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)ServiceNowClientFactory.CreatePipeline(handlers, this.testHttpMessageHandler))
            using (CompressionHandler compressionHandler = (CompressionHandler)authenticationHandler.InnerHandler)
            using (RetryHandler retryHandler = (RetryHandler)compressionHandler.InnerHandler)
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (MockRedirectHandler innerMost = (MockRedirectHandler)redirectHandler.InnerHandler)
            {
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(compressionHandler);
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(innerMost);
                Assert.IsType<AuthenticationHandler>(authenticationHandler);
                Assert.IsType<CompressionHandler>(compressionHandler);
                Assert.IsType<RetryHandler>(retryHandler);
                Assert.IsType<RedirectHandler>(redirectHandler);
                Assert.IsType<MockRedirectHandler>(innerMost);
            }
        }

        [Fact]
        public void CreatePipelineWithoutPipeline()
        {
            using (MockRedirectHandler handler = (MockRedirectHandler)ServiceNowClientFactory.CreatePipeline(null, this.testHttpMessageHandler))
            {
                Assert.NotNull(handler);
                Assert.IsType<MockRedirectHandler>(handler);
            }
        }

        [Fact]
        public void CreatePipeline_Should_Throw_Exception_With_Duplicate_Handlers()
        {
            var handlers = ServiceNowClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object);
            handlers.Add(new AuthenticationHandler(testAuthenticationProvider.Object));

            ArgumentException exception = Assert.Throws<ArgumentException>(() => ServiceNowClientFactory.CreatePipeline(handlers));

            Assert.Contains($"{typeof(AuthenticationHandler)} has a duplicate handler.", exception.Message);
        }

        [Fact]
        public void CreateClient_CustomHttpHandlingBehaviors()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var baseAddress = new Uri($"https://{this.domain}/api");
            var cacheHeader = new CacheControlHeaderValue();

            using (HttpClient client = ServiceNowClientFactory.Create(testAuthenticationProvider.Object, this.domain))
            {
                client.Timeout = timeout;
                client.BaseAddress = baseAddress;
                Assert.NotNull(client);
                Assert.Equal(timeout, client.Timeout);
                Assert.Equal(baseAddress, client.BaseAddress);
            }
        }

        [Fact]
        public void CreateClient_WithInnerHandler()
        {
            using (HttpClient httpClient = ServiceNowClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, domain: this.domain, finalHandler: this.testHttpMessageHandler))
            {
                Assert.NotNull(httpClient);
                Assert.True(httpClient.DefaultRequestHeaders.Contains(Constants.Headers.SdkVersionHeaderName), "SDK version not set.");
                Version assemblyVersion = typeof(ServiceNowClientFactory).GetTypeInfo().Assembly.GetName().Version;
                string value = string.Format(
                    Constants.Headers.SdkVersionHeaderValueFormatString,
                    "ServiceNowRestApi",
                    assemblyVersion.Major,
                    assemblyVersion.Minor,
                    assemblyVersion.Build);
                IEnumerable<string> values;
                Assert.True(httpClient.DefaultRequestHeaders.TryGetValues(Constants.Headers.SdkVersionHeaderName, out values), "SDK version value not set");
                Assert.Single(values);
                Assert.Equal(value, values.First());
            }
        }

        [Fact]
        public void CreateClient_WithHandlers()
        {
            using (HttpClient client = ServiceNowClientFactory.Create(handlers: ServiceNowClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object), domain: this.domain))
            {
                Assert.NotNull(client);
            }
        }

        [Fact]
        public async Task SendRequest_Redirect()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            var redirectResponse = new HttpResponseMessage(HttpStatusCode.MovedPermanently);

            redirectResponse.Headers.Location = new Uri("http://example.org/bar");
            var oKResponse = new HttpResponseMessage(HttpStatusCode.OK);
            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, oKResponse);

            using (HttpClient client = ServiceNowClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, domain: this.domain, finalHandler: this.testHttpMessageHandler))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Equal(oKResponse, response);
                Assert.Equal(httpRequestMessage.Method, response.RequestMessage.Method);
                Assert.NotSame(httpRequestMessage, response.RequestMessage);
            }

        }

        [Fact]
        public async Task SendRequest_Retry()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var retryResponse = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            retryResponse.Headers.TryAddWithoutValidation("Retry-After", 2.ToString());
            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            using (HttpClient client = ServiceNowClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, domain: this.domain, finalHandler: this.testHttpMessageHandler))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response_2, response);
                IEnumerable<string> values;
                Assert.True(response.RequestMessage.Headers.TryGetValues("Retry-Attempt", out values), "Don't set Retry-Attemp Header");
                Assert.Single(values);
                Assert.Equal(1.ToString(), values.First());
                Assert.NotSame(httpRequestMessage, response.RequestMessage);
            }
        }

        [Fact]
        public async Task SendRequest_UnauthorizedWithAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            using (HttpClient client = ServiceNowClientFactory.Create(handlers: handlers, this.domain, finalHandler: this.testHttpMessageHandler))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response, okResponse);
                Assert.Equal(response.RequestMessage.Headers.Authorization, new AuthenticationHeaderValue(Constants.Headers.Bearer, expectedAccessToken));
            }
        }

        [Fact]
        public void CreateClient_WithHandlersHasExceptions()
        {
            var pipelineHandlers = ServiceNowClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object).ToArray();
            pipelineHandlers[pipelineHandlers.Length - 1] = null;
            try
            {
                HttpClient client = ServiceNowClientFactory.Create(handlers: pipelineHandlers, this.domain);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsType<ArgumentNullException>(exception);
                Assert.Equal("handlers", exception.ParamName);
            }
        }

        [Fact]
        public void CreateClient_WithInnerHandlerReference()
        {
            DelegatingHandler[] handlers = new DelegatingHandler[1];
            handlers[0] = new RetryHandler(this.testHttpMessageHandler);
            // Creation should ignore the InnerHandler on RetryHandler
            HttpClient client = ServiceNowClientFactory.Create(handlers: handlers, this.domain);
            Assert.NotNull(client);
            Assert.IsType<HttpClientHandler>(handlers[0].InnerHandler);
        }

        [Fact]
        public void CreatePipelineWithFeatureFlags_Should_Set_FeatureFlag_For_Default_Handlers()
        {
            FeatureFlag expectedFlag = FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler | FeatureFlag.RedirectHandler;
            string expectedFlagHeaderValue = Enum.Format(typeof(FeatureFlag), expectedFlag, "x");
            var handlers = ServiceNowClientFactory.CreateDefaultHandlers(null);
            var pipelineWithHandlers = ServiceNowClientFactory.CreatePipelineWithFeatureFlags(handlers);

            Assert.NotNull(pipelineWithHandlers.Pipeline);
            Assert.True(pipelineWithHandlers.FeatureFlags.HasFlag(expectedFlag));
        }

        [Fact]
        public void CreatePipelineWithFeatureFlags_Should_Set_FeatureFlag_For_Speficied_Handlers()
        {
            FeatureFlag expectedFlag = FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler;
            var handlers = ServiceNowClientFactory.CreateDefaultHandlers(null);
            handlers.RemoveAt(3);
            var pipelineWithHandlers = ServiceNowClientFactory.CreatePipelineWithFeatureFlags(handlers);

            Assert.NotNull(pipelineWithHandlers.Pipeline);
            Assert.True(pipelineWithHandlers.FeatureFlags.HasFlag(expectedFlag));
        }
    }
}
