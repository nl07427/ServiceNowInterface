using System;
using System.Net;
using System.Net.Http.Headers;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>ServiceNow table API service exception.</summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Creates a new service exception.
        /// </summary>
        /// <param name="error">The error that triggered the exception.</param>
        /// <param name="innerException">The possible innerException.</param>
        public ServiceException(Error error, Exception innerException = null)
            : this(error, responseHeaders: null, statusCode: default,
                innerException: innerException)
        {
        }

        /// <summary>
        /// Creates a new service exception.
        /// </summary>
        /// <param name="error">The error that triggered the exception.</param>
        /// <param name="innerException">The possible innerException.</param>
        /// <param name="responseHeaders">The HTTP response headers from the response.</param>
        /// <param name="statusCode">The HTTP status code from the response.</param>
        public ServiceException(Error error, HttpResponseHeaders responseHeaders, HttpStatusCode statusCode,
            Exception innerException = null)
            : base(error?.ToString(), innerException)
        {
            Error = error;
            ResponseHeaders = responseHeaders;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Creates a new service exception.
        /// </summary>
        /// <param name="error">The error that triggered the exception.</param>
        /// <param name="innerException">The possible innerException.</param>
        /// <param name="responseHeaders">The HTTP response headers from the response.</param>
        /// <param name="statusCode">The HTTP status code from the response.</param>
        /// <param name="rawResponseBody">The raw JSON response body.</param>
        public ServiceException(Error error,
            HttpResponseHeaders responseHeaders,
            HttpStatusCode statusCode,
            string rawResponseBody,
            Exception innerException = null)
            : this(error, responseHeaders, statusCode, innerException)
        {
            RawResponseBody = rawResponseBody;
        }

        /// <summary>
        /// The error from the service exception.
        /// </summary>
        public Error Error { get; }

        // ResponseHeaders and StatusCode exposed as pass-through.

        /// <summary>
        /// The HTTP response headers from the response.
        /// </summary>
        public HttpResponseHeaders ResponseHeaders { get; }

        /// <summary>
        /// The HTTP status code from the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Provide the raw JSON response body.
        /// </summary>
        public string RawResponseBody { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Status Code: {StatusCode}{Environment.NewLine}{base.ToString()}";
        }
    }
}
