﻿using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Requests.Middleware
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> implementation that handles compression.
    /// </summary>
    public class CompressionHandler : DelegatingHandler
    {
        /// <summary>
        /// Constructs a new <see cref="CompressionHandler"/>.
        /// </summary>
        public CompressionHandler()
        {
        }

        /// <summary>
        /// Constructs a new <see cref="CompressionHandler"/>.
        /// </summary>
        /// <param name="innerHandler">An HTTP message handler to pass to the <see cref="HttpMessageHandler"/> for sending requests.</param>
        public CompressionHandler(HttpMessageHandler innerHandler)
            : this()
        {
            InnerHandler = innerHandler;
        }

        /// <summary>
        /// Sends a HTTP request.
        /// </summary>
        /// <param name="httpRequest">The <see cref="HttpRequestMessage"/> to be sent.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            var gzipQHeaderValue = new StringWithQualityHeaderValue(Constants.Encoding.GZip);

            // Add Accept-encoding: gzip header to incoming request if it doesn't have one.
            if (!httpRequest.Headers.AcceptEncoding.Contains(gzipQHeaderValue))
            {
                httpRequest.Headers.AcceptEncoding.Add(gzipQHeaderValue);
            }

            var response = await base.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            // Decompress response content when Content-Encoding: gzip header is present.
            if (ShouldDecompressContent(response))
            {
                StreamContent streamContent = new StreamContent(new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress));
                // Copy Content Headers to the destination stream content
                foreach (var httpContentHeader in response.Content.Headers)
                {
                    streamContent.Headers.TryAddWithoutValidation(httpContentHeader.Key, httpContentHeader.Value);
                }
                response.Content = streamContent;
            }

            return response;
        }

        /// <summary>
        /// Checks if a <see cref="HttpResponseMessage"/> contains a Content-Encoding: gzip header.
        /// </summary>
        /// <param name="httpResponse">The <see cref="HttpResponseMessage"/> to check for header.</param>
        private bool ShouldDecompressContent(HttpResponseMessage httpResponse)
        {
            return httpResponse?.Content != null && httpResponse.Content.Headers.ContentEncoding.Contains(Constants.Encoding.GZip);
        }
    }
}
