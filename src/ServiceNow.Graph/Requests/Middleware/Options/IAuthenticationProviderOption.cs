namespace ServiceNow.Graph.Requests.Middleware.Options
{
    /// <summary>
    /// An interface used to pass auth provider options in a request.
    /// Auth providers will be incharge of implementing this interface and providing <see cref="IBaseRequest"/> extensions to set it's values.
    /// </summary>
    public interface IAuthenticationProviderOption
    {
        /// <summary>
        /// Microsoft Graph scopes property.
        /// </summary>
        string[] Scopes { get; set; }
    }
}
