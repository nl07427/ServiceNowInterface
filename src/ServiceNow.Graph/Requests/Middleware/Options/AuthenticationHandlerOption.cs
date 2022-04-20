using ServiceNow.Graph.Authentication;

namespace ServiceNow.Graph.Requests.Middleware.Options
{
    /// <summary>
    /// The auth middleware option class
    /// </summary>
    public class AuthenticationHandlerOption : IMiddlewareOption
    {
        /// <summary>
        /// An authentication provider
        /// </summary>
        internal IAuthenticationProvider AuthenticationProvider { get; set; }

        /// <summary>
        /// An authentication provider option.
        /// </summary>
        public IAuthenticationProviderOption AuthenticationProviderOption { get; set; }
    }
}
