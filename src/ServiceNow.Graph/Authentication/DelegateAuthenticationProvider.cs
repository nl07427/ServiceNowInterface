using System.Net.Http;

namespace ServiceNow.Graph.Authentication
{
    /// <summary>
    /// Authenticate request async delegate.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> to authenticate.</param>
    /// <returns></returns>
    public delegate System.Threading.Tasks.Task AuthenticateRequestAsyncDelegate(HttpRequestMessage request);

    /// <summary>
    /// A default <see cref="IAuthenticationProvider"/> implementation.
    /// </summary>
    public class DelegateAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Constructs an <see cref="DelegateAuthenticationProvider"/>.
        /// </summary>
        public DelegateAuthenticationProvider(AuthenticateRequestAsyncDelegate authenticateRequestAsyncDelegate)
        {
            AuthenticateRequestAsyncDelegate = authenticateRequestAsyncDelegate;
        }

        /// <summary>
        /// Gets or sets the delegate for authenticating requests.
        /// </summary>
        public AuthenticateRequestAsyncDelegate AuthenticateRequestAsyncDelegate { get; set; }

        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to authenticate.</param>
        public System.Threading.Tasks.Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            return AuthenticateRequestAsyncDelegate != null ? AuthenticateRequestAsyncDelegate(request) : System.Threading.Tasks.Task.FromResult(0);
        }
    }
}
