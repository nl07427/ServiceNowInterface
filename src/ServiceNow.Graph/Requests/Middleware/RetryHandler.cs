using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Requests.Middleware.Options;

namespace ServiceNow.Graph.Requests.Middleware
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> implementation using standard .NET libraries.
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {
        private const string RetryAfter = "Retry-After";
        private const string RetryAttempt = "Retry-Attempt";
        private double _mPow = 1;

        /// <summary>
        /// RetryOption property
        /// </summary>
        internal RetryHandlerOption RetryOption { get; set; }

        /// <summary>
        /// Construct a new <see cref="RetryHandler"/>
        /// </summary>
        /// <param name="retryOption">An OPTIONAL <see cref="RetryHandlerOption"/> to configure <see cref="RetryHandler"/></param>
        public RetryHandler(RetryHandlerOption retryOption = null)
        {
            RetryOption = retryOption ?? new RetryHandlerOption();
        }

        /// <summary>
        /// Construct a new <see cref="RetryHandler"/>
        /// </summary>
        /// <param name="innerHandler">An HTTP message handler to pass to the <see cref="HttpMessageHandler"/> for sending requests.</param>
        /// <param name="retryOption">An OPTIONAL <see cref="RetryHandlerOption"/> to configure <see cref="RetryHandler"/></param>
        public RetryHandler(HttpMessageHandler innerHandler, RetryHandlerOption retryOption = null)
            : this(retryOption)
        {
            InnerHandler = innerHandler;
        }

        /// <summary>
        /// Send a HTTP request
        /// </summary>
        /// <param name="httpRequest">The HTTP request<see cref="HttpRequestMessage"/>needs to be sent.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest,
            CancellationToken cancellationToken)
        {
            RetryOption = httpRequest.GetMiddlewareOption<RetryHandlerOption>() ?? RetryOption;

            var response = await base.SendAsync(httpRequest, cancellationToken);

            // Check whether retries are permitted and that the MaxRetry value is a non - negative, non - zero value
            if (ShouldRetry(response) && httpRequest.IsBuffered() && RetryOption.MaxRetry > 0 &&
                RetryOption.ShouldRetry(RetryOption.Delay, 0, response))
            {
                response = await SendRetryAsync(response, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }

        /// <summary>
        /// Retry sending the HTTP request
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> which is returned and includes the HTTP request needs to be retried.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the retry.</param>
        private async Task<HttpResponseMessage> SendRetryAsync(HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            int retryCount = 0;
            var cumulativeDelay = TimeSpan.Zero;

            while (retryCount < RetryOption.MaxRetry)
            {
                // Drain response content to free responses.
                if (response.Content != null)
                {
                    await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                }

                // Call Delay method to get delay time from response's Retry-After header or by exponential backoff 
                var delay = Delay(response, retryCount, RetryOption.Delay, out double delayInSeconds,
                    cancellationToken);

                // If client specified a retries time limit, let's honor it
                if (RetryOption.RetriesTimeLimit > TimeSpan.Zero)
                {
                    // Get the cumulative delay time
                    cumulativeDelay += TimeSpan.FromSeconds(delayInSeconds);

                    // Check whether delay will exceed the client-specified retries time limit value 
                    if (cumulativeDelay > RetryOption.RetriesTimeLimit)
                    {
                        return response;
                    }
                }

                // general clone request with internal CloneAsync (see CloneAsync for details) extension method 
                var request = await response.RequestMessage.CloneAsync().ConfigureAwait(false);

                // Increase retryCount and then update Retry-Attempt in request header
                retryCount++;
                AddOrUpdateRetryAttempt(request, retryCount);

                // Delay time
                if (delay != null) await delay.ConfigureAwait(false);

                // Call base.SendAsync to send the request
                response = await base.SendAsync(request, cancellationToken);

                if (!ShouldRetry(response) || !request.IsBuffered() ||
                    !RetryOption.ShouldRetry(RetryOption.Delay, retryCount, response))
                {
                    return response;
                }
            }

            throw new ServiceException(
                new Error
                {
                    ErrorDetail = new ErrorDetail
                    {
                        Message = ErrorConstants.Codes.TooManyRetries,
                        DetailedMessage = string.Format(ErrorConstants.Messages.TooManyRetriesFormatString, retryCount)
                    }
                });
        }

        /// <summary>
        /// Update Retry-Attempt header in the HTTP request
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/>needs to be sent.</param>
        /// <param name="retryCount">Retry times</param>
        private void AddOrUpdateRetryAttempt(HttpRequestMessage request, int retryCount)
        {
            if (request.Headers.Contains(RetryAttempt))
            {
                request.Headers.Remove(RetryAttempt);
            }

            request.Headers.Add(RetryAttempt, retryCount.ToString());
        }

        /// <summary>
        /// Delay task operation for timed-retries based on Retry-After header in the response or exponential backoff
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>returned.</param>
        /// <param name="retryCount">The retry counts</param>
        /// <param name="delay">Delay value in seconds.</param>
        /// <param name="delayInSeconds"></param>
        /// <param name="cancellationToken">The cancellationToken for the Http request</param>
        /// <returns>The <see cref="Task"/> for delay operation.</returns>
        internal Task Delay(HttpResponseMessage response, int retryCount, int delay,
            out double delayInSeconds, CancellationToken cancellationToken)
        {
            HttpHeaders headers = response.Headers;
            delayInSeconds = delay;
            if (headers.TryGetValues(RetryAfter, out IEnumerable<string> values))
            {
                var retryAfter = values.First();
                if (int.TryParse(retryAfter, out var delaySeconds))
                {
                    delayInSeconds = delaySeconds;
                }
            }
            else
            {
                _mPow = Math.Pow(2, retryCount);
                delayInSeconds = _mPow * delay;
            }

            var delayTimeSpan = TimeSpan.FromSeconds(Math.Min(delayInSeconds, RetryHandlerOption.MaxDelay));

            return Task.Delay(delayTimeSpan, cancellationToken);
        }

        /// <summary>
        /// Check the HTTP response's status to determine whether it should be retried or not.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>returned.</param>
        private bool ShouldRetry(HttpResponseMessage response)
        {
            return response != null && (response.StatusCode == HttpStatusCode.ServiceUnavailable ||
                                        response.StatusCode == HttpStatusCode.GatewayTimeout ||
                                        response.StatusCode == (HttpStatusCode) 429);
        }
    }
}
