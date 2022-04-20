using System;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>
    /// ServiceNow Table API client exception.
    /// </summary>
#pragma warning disable RCS1194 // Implement exception constructors.
    public class ClientException : ServiceException
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        /// <summary>
        /// Creates a new client exception.
        /// </summary>
        /// <param name="error">The error that triggered the exception.</param>
        /// <param name="innerException">The possible innerException.</param>
        public ClientException(Error error, Exception innerException = null) : base(error, innerException)
        {
        }
    }
}
