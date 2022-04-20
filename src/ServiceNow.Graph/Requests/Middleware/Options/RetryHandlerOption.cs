using System;
using System.Net.Http;
using ServiceNow.Graph.Exceptions;

namespace ServiceNow.Graph.Requests.Middleware.Options
{
    /// <summary>
    /// The retry middleware option class
    /// </summary>
    public class RetryHandlerOption : IMiddlewareOption
    {
        internal const int DefaultDelay = 3;
        internal const int DefaultMaxRetry = 3;
        internal const int MaxMaxRetry = 10;
        internal const int MaxDelay = 180;

        private int _delay = DefaultDelay;

        /// <summary>
        /// The waiting time in seconds before retrying a request with a maximum value of 180 seconds. This defaults to 3 seconds.
        /// </summary>
        public int Delay
        {
            get => _delay;
            set
            {
                if (value > MaxDelay)
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail()
                            {
                                DetailedMessage = string.Format(ErrorConstants.Messages.MaximumValueExceeded, "Delay",
                                    MaxDelay),
                                Message = ErrorConstants.Codes.MaximumValueExceeded
                            }
                        });
                }

                _delay = value;
            }
        }

        private int _maxRetry = DefaultMaxRetry;

        /// <summary>
        /// The maximum number of retries for a request with a maximum value of 10. This defaults to 3.
        /// </summary>
        public int MaxRetry
        {
            get => _maxRetry;
            set
            {
                if (value > MaxMaxRetry)
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                DetailedMessage = string.Format(ErrorConstants.Messages.MaximumValueExceeded,
                                    "MaxRetry", MaxMaxRetry),
                                Message = ErrorConstants.Codes.MaximumValueExceeded
                            }
                        });
                }

                _maxRetry = value;
            }
        }

        /// <summary>
        /// The maximum time allowed for request retries.
        /// </summary>
        public TimeSpan RetriesTimeLimit { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// A delegate that's called to determine whether a request should be retried or not.
        /// The delegate method should accept a delay time in seconds of, number of retry attempts and <see cref="HttpResponseMessage"/> as it's parameters and return a <see cref="bool"/>. This defaults to true
        /// </summary>
        public Func<int, int, HttpResponseMessage, bool> ShouldRetry { get; set; } = (_, ___, __) => true;
    }
}
