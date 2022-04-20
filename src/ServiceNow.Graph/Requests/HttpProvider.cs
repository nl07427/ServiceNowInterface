using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// An <see cref="IHttpProvider"/> implementation using standard .NET libraries.
    /// </summary>
    public class HttpProvider : IHttpProvider
    {
        internal bool DisposeHandler;

        internal HttpClient HttpClient;

        internal HttpMessageHandler HttpMessageHandler;

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="domain">Domain name of ServiceNow instance</param>
        /// <param name="version">Version of the API to use, defaults to the latest (now)</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(string domain, string version = "now", ISerializer serializer = null)
            : this((HttpMessageHandler) null, true,domain, version, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpClientHandler">An HTTP client handler to pass to the <see cref="System.Net.Http.HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="domain">Domain name of ServiceNow instance</param>
        /// <param name="version">Version of the API to use, defaults to the latest (now)</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        /// <remarks>
        ///     By default, HttpProvider disables automatic redirects and handles redirects to preserve authentication headers. If providing
        ///     an <see cref="HttpClientHandler"/> to the constructor and enabling automatic redirects this could cause issues with authentication
        ///     over the redirect.
        /// </remarks>
        public HttpProvider(HttpClientHandler httpClientHandler, bool disposeHandler, string domain, string version = "now",
            ISerializer serializer = null)
            : this((HttpMessageHandler) httpClientHandler, disposeHandler,domain,version, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpMessageHandler">An HTTP message handler to pass to the <see cref="System.Net.Http.HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="domain">Domain name of ServiceNow instance</param>
        /// <param name="version">Version of the API to use, defaults to the latest (now)</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(HttpMessageHandler httpMessageHandler, bool disposeHandler, string domain,
            string version = "now",
            ISerializer serializer = null)
        {
            DisposeHandler = disposeHandler;
            HttpMessageHandler = httpMessageHandler;
            Serializer = serializer ?? new Serializer(new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });

            // NOTE: Override our pipeline when a httpMessageHandler is provided - httpMessageHandler can implement custom pipeline.
            if (HttpMessageHandler == null)
            {
                HttpMessageHandler = ServiceNowClientFactory.GetHttpHandler();
                HttpClient = ServiceNowClientFactory.Create(authenticationProvider: null, domain, version,
                    finalHandler: HttpMessageHandler);
            }
            else
            {
                HttpClient = new HttpClient(this.HttpMessageHandler, this.DisposeHandler);
            }

            HttpClient.Timeout = new TimeSpan(0, 0,15 ,0,0);

            HttpClient.SetFeatureFlag(FeatureFlag.DefaultHttpProvider);
        }

        /// <summary>
        /// Gets or sets the cache control header for requests;
        /// </summary>
        public CacheControlHeaderValue CacheControlHeader
        {
            get => HttpClient.DefaultRequestHeaders.CacheControl;

            set => HttpClient.DefaultRequestHeaders.CacheControl = value;
        }

        /// <summary>
        /// Gets or sets the overall request timeout.
        /// </summary>
        public TimeSpan OverallTimeout
        {
            get => HttpClient.Timeout;

            set
            {
                try
                {
                    HttpClient.Timeout = value;
                }
                catch (InvalidOperationException exception)
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.NotAllowed,
                                DetailedMessage = ErrorConstants.Messages.OverallTimeoutCannotBeSet
                            }
                        },
                        exception);
                }
            }
        }

        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        public ISerializer Serializer { get; }

        /// <summary>
        /// Disposes the HttpClient and HttpClientHandler instances.
        /// </summary>
        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            var response = await this.SendRequestAsync(request, completionOption, cancellationToken)
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode) return response;
            using (response)
            {
                if (response.Content != null)
                {
                    await response.Content.LoadIntoBufferAsync().ConfigureAwait(false);
                }

                var errorResponse = await ConvertErrorResponseAsync(response).ConfigureAwait(false);
                Error error;

                if (errorResponse == null)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        error = new Error
                            {ErrorDetail = new ErrorDetail {Message = ErrorConstants.Codes.ItemNotFound, DetailedMessage = ErrorConstants.Codes.ItemNotFound} };
                    }
                    else
                    {
                        error = new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.GeneralException,
                                DetailedMessage = ErrorConstants.Messages.UnexpectedExceptionResponse,
                            }
                        };
                    }
                }
                else
                {
                    error = errorResponse;
                }

                if (string.IsNullOrEmpty(error.ClientRequestId))
                {
                    if (response.Headers.TryGetValues(Constants.Headers.ClientRequestId, out var clientRequestId))
                    {
                        error.ClientRequestId = clientRequestId.FirstOrDefault();
                    }
                }

                if (response.Content == null)
                    throw new ServiceException(error, response.Headers, response.StatusCode);
                var rawResponseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Pass through the response headers and status code to the ServiceException.
                // System.Net.HttpStatusCode does not support RFC 6585, Additional HTTP Status Codes.
                // Throttling status code 429 is in RFC 6586. The status code 429 will be passed through.
                throw new ServiceException(error,
                    response.Headers,
                    response.StatusCode,
                    rawResponseBody);
            }
        }

        internal async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await HttpClient.SendAsync(request, completionOption, cancellationToken)
                    .ConfigureAwait(false);
                return response;
            }
            catch (TaskCanceledException exception)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail
                        {
                            Message = ErrorConstants.Codes.Timeout,
                            DetailedMessage = ErrorConstants.Messages.RequestTimedOut
                        }
                    },
                    exception);
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail
                        {
                            Message = ErrorConstants.Codes.GeneralException,
                            DetailedMessage = ErrorConstants.Messages.UnexpectedExceptionOnSend,
                        }
                    },
                    exception);
            }
        }

        /// <summary>
        /// Converts the <see cref="HttpRequestException"/> into an <see cref="ErrorResponse"/> object;
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to convert.</param>
        /// <returns>The <see cref="ErrorResponse"/> object.</returns>
        private async Task<Error> ConvertErrorResponseAsync(HttpResponseMessage response)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                return Serializer.DeserializeObject<Error>(responseStream);
            }
        }
    }
}
