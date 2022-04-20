using System;
using System.Net.Http;
using ServiceNow.Graph.Exceptions;

namespace ServiceNow.Graph.Requests.Middleware.Options
{
    /// <summary>
    /// The redirect middleware option class
    /// </summary>
    public class RedirectHandlerOption : IMiddlewareOption
    {
        internal const int DefaultMaxRedirect = 5;
        internal const int MaxMaxRedirect = 20;
        private int _maxRedirect = DefaultMaxRedirect;

        /// <summary>
        /// The maximum number of redirects with a maximum value of 20. This defaults to 5 redirects.
        /// </summary>
        public int MaxRedirect
        {
            get => _maxRedirect;
            set
            {
                if (value > MaxMaxRedirect)
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail()
                            {
                                Message = ErrorConstants.Codes.MaximumValueExceeded,
                                DetailedMessage = string.Format(ErrorConstants.Messages.MaximumValueExceeded,
                                    "MaxRedirect", MaxMaxRedirect)
                            }
                        });
                }

                _maxRedirect = value;
            }
        }

        /// <summary>
        /// A delegate that's called to determine whether a response should be redirected or not. The delegate method should accept <see cref="HttpResponseMessage"/> as it's parameter and return a <see cref="bool"/>. This defaults to true.
        /// </summary>
        public Func<HttpResponseMessage, bool> ShouldRedirect { get; set; } = _ => true;
    }
}
