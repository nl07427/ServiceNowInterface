using System;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>
    /// ServiceNow authentication exception
    /// </summary>
    public class AuthenticationException : Exception
    {
        /// <summary>
        /// Creates a new authentication exception.
        /// </summary>
        /// <param name="error">The error that triggered the exception.</param>
        /// <param name="innerException">The possible inner exception.</param>
        public AuthenticationException(Error error, Exception innerException = null)
            : base(error?.ToString(), innerException)
        {
            Error = error;
        }

        /// <summary>
        /// The error from the authentication exception.
        /// </summary>
        public Error Error { get; private set; }
    }
}
