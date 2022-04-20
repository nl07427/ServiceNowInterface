using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserCollectionRequestBuilder.
    /// </summary>
    public interface IUsersCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IUsersCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IUsersCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IUserRequestBuilder"/> for the specified user.
        /// </summary>
        /// <param name="id">The id (sys_id) for the user.</param>
        /// <returns>The <see cref="IUserRequestBuilder"/>.</returns>
        IUserRequestBuilder this[string id] { get; }
    }
}
