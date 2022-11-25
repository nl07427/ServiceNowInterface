using ServiceNow.Graph.Exceptions;
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
    }
}
