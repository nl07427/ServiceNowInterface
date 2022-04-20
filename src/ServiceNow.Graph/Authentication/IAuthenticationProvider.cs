using System.Net.Http;

namespace ServiceNow.Graph.Authentication
{
    /// <summary>
    /// Interface for authenticating requests.
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to authenticate.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task AuthenticateRequestAsync(HttpRequestMessage request);
    }
}
