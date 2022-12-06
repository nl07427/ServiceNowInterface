using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests.Middleware;
using ServiceNow.Graph.Test.Mocks;
using Xunit;

namespace ServiceNow.Graph.Test.Requests.Middleware
{
    public class CompressionHandlerTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private CompressionHandler compressionHandler;
        private HttpMessageInvoker invoker;

        public CompressionHandlerTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            this.compressionHandler = new CompressionHandler(this.testHttpMessageHandler);
            this.invoker = new HttpMessageInvoker(this.compressionHandler);
        }

        public void Dispose()
        {
            this.invoker.Dispose();
        }

        [Fact]
        public void CompressionHandler_should_construct_handler()
        {
            Assert.NotNull(this.compressionHandler.InnerHandler);
        }

        [Fact]
        public async Task CompressionHandler_should_add_accept_encoding_gzip_header_when_non_is_present()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(httpResponse);
            HttpResponseMessage response = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Same(httpRequestMessage, response.RequestMessage);
            Assert.Contains(new StringWithQualityHeaderValue(Constants.Encoding.GZip), response.RequestMessage.Headers.AcceptEncoding);
        }

        [Fact]
        public async Task CompressionHandler_should_decompress_response_with_content_encoding_gzip_header()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            httpRequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(Constants.Encoding.GZip));
            string stringToCompress = "sample string content";

            // Compress response
            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new MockCompressedContent(new StringContent(stringToCompress))
            };
            httpResponse.Content.Headers.ContentEncoding.Add(Constants.Encoding.GZip);

            this.testHttpMessageHandler.SetHttpResponse(httpResponse);

            HttpResponseMessage decompressedResponse = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            string responseContentString = await decompressedResponse.Content.ReadAsStringAsync();

            Assert.Same(httpResponse, decompressedResponse);
            Assert.Same(httpRequestMessage, decompressedResponse.RequestMessage);
            Assert.Equal(stringToCompress, responseContentString);
        }

        [Fact]
        public async Task CompressionHandler_should_not_decompress_response_without_content_encoding_gzip_header()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            string stringToCompress = "ServiceNow Graph";

            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new MockCompressedContent(new StringContent(stringToCompress))
            };
            this.testHttpMessageHandler.SetHttpResponse(httpResponse);

            HttpResponseMessage compressedResponse = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            string responseContentString = await compressedResponse.Content.ReadAsStringAsync();

            Assert.Same(httpResponse, compressedResponse);
            Assert.Same(httpRequestMessage, compressedResponse.RequestMessage);
            Assert.NotEqual(stringToCompress, responseContentString);
        }

        /// <summary>
        /// Compression Handler should keep content headers after decompression
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CompressionHandler_should_keep_headers_after_decompression()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            string stringToCompress = "ServiceNow Graph";
            StringContent stringContent = new StringContent(stringToCompress);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new MockCompressedContent(stringContent)
            };
            httpResponse.Content.Headers.ContentEncoding.Add(Constants.Encoding.GZip);
            httpResponse.Headers.CacheControl = new CacheControlHeaderValue { Private = true };
            // Examples of Custom Headers returned by ServiceNow Graph
            httpResponse.Headers.Add(Constants.Headers.ClientRequestId, Guid.NewGuid().ToString());
            httpResponse.Headers.Add("request-id", Guid.NewGuid().ToString());
            httpResponse.Headers.Add("OData-Version", "4.0");

            this.testHttpMessageHandler.SetHttpResponse(httpResponse);

            HttpResponseMessage compressedResponse = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            string decompressedResponseString = await compressedResponse.Content.ReadAsStringAsync();

            Assert.Equal(decompressedResponseString, stringToCompress);

            // Ensure that headers in the compressedResponse are the same as in the original, expected response.
            Assert.NotEmpty(compressedResponse.Headers);
            Assert.NotEmpty(compressedResponse.Content.Headers);
            Assert.Equal(httpResponse.Headers, compressedResponse.Headers, new HttpHeaderComparer());
            Assert.Equal(httpResponse.Content.Headers, compressedResponse.Content.Headers, new HttpHeaderComparer());
        }

        internal class HttpHeaderComparer : IEqualityComparer<KeyValuePair<string, IEnumerable<string>>>
        {
            public bool Equals(KeyValuePair<string, IEnumerable<string>> x, KeyValuePair<string, IEnumerable<string>> y)
            {
                // For each key, the collection of header values should be equal.
                return x.Key == y.Key && x.Value.SequenceEqual(y.Value);
            }

            public int GetHashCode(KeyValuePair<string, IEnumerable<string>> obj)
            {
                return obj.Key.GetHashCode();
            }
        }
    }
}
