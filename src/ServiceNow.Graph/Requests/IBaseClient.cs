using System;
using ServiceNow.Graph.Authentication;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Interface for the base client.
    /// </summary>
    public interface IBaseClient
    {
        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating HTTP requests.
        /// </summary>
        IAuthenticationProvider AuthenticationProvider { get; }

        /// <summary>
        /// Gets the domain of the ServiceNow instance.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// Gets the version of the ServiceNow api.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        IHttpProvider HttpProvider { get; }

        /// <summary>
        /// Gets or Sets the <see cref="IAuthenticationProvider"/> for authenticating a single HTTP requests.
        /// </summary>
        Func<IAuthenticationProvider> PerRequestAuthProvider { get; set; }
    }
}
