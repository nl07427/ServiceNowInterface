using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// An <see cref="IHttpProvider"/> implementation using standard .NET libraries.
    /// </summary>
    public class SimpleHttpProvider : IHttpProvider
    {
        internal readonly HttpClient HttpClient;

        /// <summary>
        /// Constructs a new <see cref="SimpleHttpProvider"/>.
        /// </summary>
        /// <param name="httpClient">Custom http client to be used for making requests</param>
        /// <param name="domain"></param>
        /// <param name="version"></param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public SimpleHttpProvider(HttpClient httpClient, string domain, string version = "",
            ISerializer serializer = null)
        {
            HttpClient = httpClient ?? ServiceNowClientFactory.Create(authenticationProvider: null, domain: domain, version);
            Serializer = serializer ?? new Serializer(new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });
        }

        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        public ISerializer Serializer { get; }

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
                        }, exception);
                }
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
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
            var response = await SendRequestAsync(request, completionOption, cancellationToken)
                .ConfigureAwait(false);

            // check if the response is of a successful nature.
            if (response.IsSuccessStatusCode) return response;
            using (response)
            {
                if (response.Content != null)
                {
                    await response.Content.LoadIntoBufferAsync().ConfigureAwait(false);
                }

                var errorResponse = await ConvertErrorResponseAsync(response).ConfigureAwait(false);
                Error error;

                if (errorResponse?.Error == null)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        error = new Error
                            {ErrorDetail = new ErrorDetail {Message = ErrorConstants.Codes.ItemNotFound}};
                    }
                    else
                    {
                        error = new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.GeneralException,
                                DetailedMessage = ErrorConstants.Messages.UnexpectedExceptionResponse
                            }
                        };
                    }
                }
                else
                {
                    error = errorResponse.Error;
                }

                if (string.IsNullOrEmpty(error.ClientRequestId) && response.Headers.TryGetValues(Constants.Headers.ClientRequestId, out var clientRequestId))
                {
                    error.ClientRequestId = clientRequestId.FirstOrDefault();
                }

                if (response.Content?.Headers.ContentType.MediaType != "application/json")
                    throw new ServiceException(error, response.Headers, response.StatusCode);

                var rawResponseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                throw new ServiceException(error,
                    response.Headers,
                    response.StatusCode,
                    rawResponseBody);

                // Pass through the response headers and status code to the ServiceException.
                // System.Net.HttpStatusCode does not support RFC 6585, Additional HTTP Status Codes.
                // Throttling status code 429 is in RFC 6586. The status code 429 will be passed through.
            }
        }

        /// <summary>
        /// Disposes the HttpClient and HttpClientHandler instances.
        /// </summary>
        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        /// <summary>
        /// Converts the <see cref="HttpRequestException"/> into an <see cref="ErrorResponse"/> object;
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to convert.</param>
        /// <returns>The <see cref="ErrorResponse"/> object.</returns>
        private async Task<ErrorResponse> ConvertErrorResponseAsync(HttpResponseMessage response)
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return Serializer.DeserializeObject<ErrorResponse>(responseStream);
                }
            }
            catch (Exception)
            {
                // If there's an exception deserializing the error response return null and throw a generic
                // ServiceException later.
                return null;
            }
        }

        private async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                return await HttpClient.SendAsync(request, completionOption, cancellationToken)
                    .ConfigureAwait(false);
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
                            DetailedMessage = ErrorConstants.Messages.UnexpectedExceptionOnSend
                        }
                    },
                    exception);
            }
        }
    }
}
