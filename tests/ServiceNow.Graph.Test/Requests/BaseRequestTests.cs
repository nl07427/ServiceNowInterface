﻿using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests.Options;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Requests.Middleware.Options;
using ServiceNow.Graph.Test.TestModels;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.Requests
{
    public class BaseRequestTests : RequestTestBase
    {
        [Fact]
        public void BaseRequest_InitializeWithEmptyBaseUrl()
        {
            ServiceException exception = Assert.Throws<ServiceException>(() => new BaseRequest(null, this.baseClient));
            Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.BaseUrlMissing, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Theory]
        [InlineData("contains(subject, '#')", "contains%28subject%2C%20%27%23%27%29")]
        [InlineData("contains(subject, '?')", "contains%28subject%2C%20%27%3F%27%29")]
        [InlineData("contains(subject,'Überweisung')", "contains%28subject%2C%27%C3%9Cberweisung%27%29")]
        [InlineData("contains%28subject%2C%27%C3%9Cberweisung%27%29", "contains%28subject%2C%27%C3%9Cberweisung%27%29")]//ensure we do not double encode parameters if already encoded
        public void BaseRequest_InitializeWithQueryOptionsWillUrlEncodeQueryOptions(string filterClause, string expectedQueryParam)
        {
            // Arrange
            var requestUrl = string.Concat(this.baseUrl, "/users");
            var options = new List<Option>
            {
                new QueryOption("$filter", filterClause),
            };
            var expectedUrl = $"https://localhost/v1.0/users?$filter={expectedQueryParam}";

            // Act
            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options);
            var requestMessage = baseRequest.GetHttpRequestMessage();


            Assert.Equal(new Uri(requestUrl), new Uri(baseRequest.RequestUrl));
            Assert.Equal(1, baseRequest.QueryOptions.Count);
            Assert.Equal(expectedUrl, requestMessage.RequestUri.AbsoluteUri);
        }

        [Fact]
        public void BaseRequest_InitializeWithQueryStringAndOptions()
        {
            var baseUrl = string.Concat(this.baseUrl, "/me/drive/items/id");
            var requestUrl = baseUrl + "?key=value&key2";

            var options = new List<Option>
            {
                new QueryOption("key3", "value3"),
                new HeaderOption("header", "value"),
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options);

            Assert.Equal(new Uri(baseUrl), new Uri(baseRequest.RequestUrl));
            Assert.Equal(3, baseRequest.QueryOptions.Count);
            Assert.True(baseRequest.QueryOptions[0].Name.Equals("key") && baseRequest.QueryOptions[0].Value.Equals("value"));
            Assert.True(baseRequest.QueryOptions[1].Name.Equals("key2") && string.IsNullOrEmpty(baseRequest.QueryOptions[1].Value));
            Assert.True(baseRequest.QueryOptions[2].Name.Equals("key3") && baseRequest.QueryOptions[2].Value.Equals("value3"));
            Assert.Equal(1, baseRequest.Headers.Count);
            Assert.True(baseRequest.Headers[0].Name.Equals("header") && baseRequest.Headers[0].Value.Equals("value"));
            Assert.NotNull(baseRequest.Client.AuthenticationProvider);
            Assert.NotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId);
            Assert.Equal(baseRequest.GetHttpRequestMessage().GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider, baseRequest.Client.AuthenticationProvider);
        }

        [Fact]
        public void GetWebRequestWithHeadersAndQueryOptions()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var options = new List<Option>
            {
                new HeaderOption("header1", "value1"),
                new HeaderOption("header2", "value2"),
                new QueryOption("query1", "value1"),
                new QueryOption("query2", "value2"),
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();
            Assert.Equal(HttpMethod.Put, httpRequestMessage.Method);
            Assert.Equal(requestUrl + "?query1=value1&query2=value2",
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped));
            Assert.Equal("value1", httpRequestMessage.Headers.GetValues("header1").First());
            Assert.Equal("value2", httpRequestMessage.Headers.GetValues("header2").First());
            Assert.NotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId);
        }

        [Fact]
        public void GetRequestContextWithClientRequestIdHeader()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");
            string clientRequestId = "foobar";
            var headers = new List<HeaderOption>
            {
                new HeaderOption(Constants.Headers.ClientRequestId, clientRequestId)
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, headers) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.Equal(HttpMethod.Put, httpRequestMessage.Method);
            Assert.Same(clientRequestId, httpRequestMessage.GetRequestContext().ClientRequestId);
        }

        [Fact]
        public void GetRequestContextWithClientRequestId()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.Equal(HttpMethod.Put, httpRequestMessage.Method);
            Assert.NotNull(httpRequestMessage.GetRequestContext().ClientRequestId);
        }

        [Fact]
        public void GetRequestNoAuthProvider()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");

            var client = new BaseClient(domain: this.baseUrl, authenticationProvider: null);
            var baseRequest = new BaseRequest(requestUrl, client) { Method = "PUT"};

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.Equal(HttpMethod.Put, httpRequestMessage.Method);
            Assert.NotNull(httpRequestMessage.GetRequestContext().ClientRequestId);
            Assert.Null(httpRequestMessage.GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider);
        }

        [Fact]
        public void GetWebRequestNoOptions()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { Method = "DELETE" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();
            Assert.Equal(HttpMethod.Delete, httpRequestMessage.Method);
            Assert.Equal(requestUrl,
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped));
            Assert.Empty(httpRequestMessage.Headers);
        }

        [Fact]
        public async Task SendAsync()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                var expectedResponseItem = new DerivedTypeClass { Id = "id" };
                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<String>()))
                    .Returns(expectedResponseItem);

                var responseItem = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.NotNull(responseItem);
                Assert.Equal(expectedResponseItem.Id, responseItem.Id);
                Assert.NotNull(baseRequest.Client.AuthenticationProvider);
                Assert.NotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId);
                Assert.Equal(baseRequest.GetHttpRequestMessage().GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider,
                    baseRequest.Client.AuthenticationProvider);
            }
        }

        [Fact]
        public async Task SendAsyncSupportsContentTypeWithParameters()
        {
            // Arrange
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            // Create a request that has content type with parameters 
            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json; odata=verbose" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json; odata=verbose")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                var expectedResponseItem = new DerivedTypeClass { Id = "id" };
                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<String>()))
                    .Returns(expectedResponseItem);

                // Act
                var responseItem = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                // Assert
                Assert.NotNull(responseItem);
                Assert.Equal(expectedResponseItem.Id, responseItem.Id);
                Assert.NotNull(baseRequest.Client.AuthenticationProvider);
                Assert.NotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId);
                Assert.Equal(baseRequest.GetHttpRequestMessage().GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider,
                    baseRequest.Client.AuthenticationProvider);
                Assert.Equal("application/json; odata=verbose", baseRequest.ContentType);
            }
        }
        
        [Fact]
        public async Task SendAsync_AuthenticationProviderNotSetWithCustomIHttpProvider()
        {
            var client = new BaseClient("https://localhost", null, this.httpProvider.Object);
            var baseRequest = new BaseRequest("https://localhost", client);
            ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None));
            Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.AuthenticationProviderMissing, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public async Task SendAsync_NoReturnObject()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                await baseRequest.SendAsync("string", CancellationToken.None);
                Assert.NotNull(baseRequest.Client.AuthenticationProvider);
            }
        }

        [Fact]
        public async Task SendAsync_NullResponseBody()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json"};

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            {
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<String>()))
                    .Returns((string responseString) => {
                        if (String.IsNullOrEmpty(responseString))
                            return default(DerivedTypeClass);
                        else
                            return new DerivedTypeClass { Id = "id" };
                    });

                var instance = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.Null(instance);
            }
        }

        [Fact]
        public async Task SendAsync_RequestUrlNotSet()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);
            baseRequest.RequestUrl = null;

            ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None));
            Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.RequestUrlMissing, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public async Task SendStreamRequestAsync()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/photo/$value");
            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json", Method = "PUT" };

            using (var requestStream = new MemoryStream())
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Put),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var returnedResponseStream = await baseRequest.SendStreamRequestAsync(requestStream, CancellationToken.None))
                {
                    Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
                }
            }
        }

        [Fact]
        public async Task SendAsync_WithCustomHttpProvider()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (TestHttpMessageHandler testHttpMessageHandler = new TestHttpMessageHandler())
            {
                string requestUrl = "https://localhost/";
                testHttpMessageHandler.AddResponseMapping(requestUrl, httpResponseMessage);
                MockCustomHttpProvider customHttpProvider = new MockCustomHttpProvider(testHttpMessageHandler);

                BaseClient client = new BaseClient(requestUrl, authenticationProvider.Object, customHttpProvider);
                BaseRequest baseRequest = new BaseRequest(requestUrl, client);

                HttpResponseMessage returnedResponse = await baseRequest.SendRequestAsync("string", CancellationToken.None);

                Assert.Equal(httpResponseMessage, returnedResponse);
                Assert.NotNull(returnedResponse.RequestMessage.Headers);
                Assert.Equal("Default-Token", returnedResponse.RequestMessage.Headers.Authorization.Parameter);
            }
        }

        [Fact]
        public void BuildQueryString_NullQueryOptions()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);

            baseRequest.QueryOptions = null;

            var queryString = baseRequest.BuildQueryString();

            Assert.Null(queryString);
        }

        [Fact]
        public async Task BaseRequest_Should_Call_HttpProvider_Concurrently()
        {
            var tasks = Enumerable.Range(1, 50).Select(index =>
            {
                return Task.Run(async () =>
                {

                    string expectedToken = Guid.NewGuid().ToString();
                    var authProviderTriggered = 0;
                    var authProvider = new DelegateAuthenticationProvider(message =>
                    {
                        authProviderTriggered++;
                        message.Headers.Authorization = new AuthenticationHeaderValue("bearer", expectedToken);
                        return Task.CompletedTask;
                    });

                    var validationHandlerTriggered = 0;
                    var validationHandler = new TestHttpMessageHandler(message =>
                    {
                        validationHandlerTriggered++;
                        Assert.Equal(expectedToken, message.Headers?.Authorization?.Parameter);
                        Assert.Equal("https://test/users", message.RequestUri.AbsoluteUri);
                    });

                    var httpProvider = new HttpProvider(
                        validationHandler,
                        true,
                        "local",
                        new Serializer());

                    var client = new BaseClient("https://Test", authProvider, httpProvider);
                    var baseRequest = new BaseRequest("https://Test/users", client);
                    await baseRequest.SendAsync(new object(), CancellationToken.None);

                    Assert.Equal(1, validationHandlerTriggered);
                    Assert.Equal(1, authProviderTriggered);
                });
            });

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        [Fact]
        public void BaseRequest_Should_Set_ResponseHandler()
        {
            // Arrange
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");
            var baseRequest = new BaseRequest(requestUrl, this.baseClient);
            var customResponseHandler = new ResponseHandler(this.serializer.Object);
            // Act

            baseRequest.WithResponseHandler<BaseRequest>(customResponseHandler);

            // Assert
            Assert.NotNull(baseRequest.ResponseHandler);
            Assert.Equal(customResponseHandler, baseRequest.ResponseHandler);
        }
    }
}
