using ServiceNow.Graph.Requests.Middleware.Options;
using ServiceNow.Graph.Requests.Middleware;
using ServiceNow.Graph.Test.Mocks;
using System.Net.Http;
using System.Net;
using System.Threading;
using System;
using Xunit;
using System.Collections.Generic;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Test.Requests.Middleware
{
    public class AuthenticationHandlerTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private AuthenticationHandler authenticationHandler;
        private MockAuthenticationProvider mockAuthenticationProvider;
        private HttpMessageInvoker invoker;

        public AuthenticationHandlerTests()
        {
            testHttpMessageHandler = new MockRedirectHandler();
            mockAuthenticationProvider = new MockAuthenticationProvider();
            authenticationHandler = new AuthenticationHandler(mockAuthenticationProvider.Object, testHttpMessageHandler);
            invoker = new HttpMessageInvoker(authenticationHandler);
        }

        public void Dispose()
        {
            invoker.Dispose();
            authenticationHandler.Dispose();
            testHttpMessageHandler.Dispose();
        }

        [Fact]
        public void AuthHandler_AuthProviderConstructor()
        {
            using (AuthenticationHandler auth = new AuthenticationHandler(mockAuthenticationProvider.Object))
            {
                Assert.Null(auth.InnerHandler);
                Assert.NotNull(auth.AuthenticationProvider);
                Assert.NotNull(auth.AuthOption);
                Assert.IsType<AuthenticationHandler>(auth);
            }
        }

        [Fact]
        public void AuthHandler_AuthProviderHttpMessageHandlerConstructor()
        {
            Assert.NotNull(authenticationHandler.InnerHandler);
            Assert.NotNull(authenticationHandler.AuthenticationProvider);
            Assert.NotNull(authenticationHandler.AuthOption);
            Assert.IsType<AuthenticationHandler>(authenticationHandler);
        }

        [Fact]
        public void AuthHandler_AuthProviderAuthOptionConstructor()
        {
            var scopes = new string[] { "foo.bar" };
            using (AuthenticationHandler auth = new AuthenticationHandler(mockAuthenticationProvider.Object,
                new AuthenticationHandlerOption()))
            {
                Assert.Null(auth.InnerHandler);
                Assert.NotNull(auth.AuthenticationProvider);
                Assert.NotNull(auth.AuthOption);
                Assert.IsType<AuthenticationHandler>(auth);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.MovedPermanently)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.GatewayTimeout)]
        public async void AuthHandler_NonUnauthorizedStatusShouldPassThrough(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            var expectedResponse = new HttpResponseMessage(statusCode);

            testHttpMessageHandler.SetHttpResponse(expectedResponse);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Same(response, expectedResponse);
            Assert.Same(httpRequestMessage, response.RequestMessage);
        }
        [Fact]
        public async void AuthHandler_ShouldRetryUnauthorizedGetRequest()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.com/bar");
            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, expectedResponse);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Same(response, expectedResponse);
            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.Null(response.RequestMessage.Content);
        }

        [Fact]
        public async void AuthHandler_ShouldRetryUnauthorizedGetRequestUsingAuthHandlerOption()
        {
            DelegatingHandler authHandler = new AuthenticationHandler(null, testHttpMessageHandler);
            using (HttpMessageInvoker msgInvoker = new HttpMessageInvoker(authHandler))
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.com/bar"))
            using (var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized))
            using (var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK))
            {
                httpRequestMessage.Properties.Add(typeof(ServiceNowRequestContext).ToString(), new ServiceNowRequestContext
                {
                    MiddlewareOptions = new Dictionary<string, IMiddlewareOption>() {
                        {
                            typeof(AuthenticationHandlerOption).ToString(),
                            new AuthenticationHandlerOption { AuthenticationProvider = mockAuthenticationProvider.Object }
                        }
                    }
                });
                testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, expectedResponse);

                var response = await msgInvoker.SendAsync(httpRequestMessage, new CancellationToken());

                Assert.NotSame(response.RequestMessage, httpRequestMessage);
                Assert.Same(response, expectedResponse);
                Assert.Null(response.RequestMessage.Content);
            }
        }

        [Fact]
        public async void AuthHandler_ShouldRetryUnauthorizedPostRequestWithNoContent()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.com/bar");
            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, expectedResponse);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.Same(response, expectedResponse);
            Assert.NotSame(response, unauthorizedResponse);
            Assert.Null(response.RequestMessage.Content);
        }

        [Fact]
        public async void AuthHandler_ShouldRetryUnauthorizedPostRequestWithBufferContent()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World!");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.Same(response, okResponse);
            Assert.NotSame(response, unauthorizedResponse);
            Assert.NotNull(response.RequestMessage.Content);
            Assert.Equal("Hello World!", response.RequestMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
