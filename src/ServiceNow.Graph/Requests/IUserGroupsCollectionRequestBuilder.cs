using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserGroupsCollectionRequestBuilder.
    /// </summary>
    public interface IUserGroupsCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IUserGroupCollectionRequest  Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IUserGroupCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IUserGroupRequestBuilder"/> for the specified group.
        /// </summary>
        /// <param name="id">The id (sys_id) for group.</param>
        /// <returns>The <see cref="IUserGroupRequestBuilder"/>.</returns>
        IUserGroupRequestBuilder this[string id] { get; }
    }
}
