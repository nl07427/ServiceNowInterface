using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IRoleHasRolesCollectionRequestBuilder
    /// </summary>
    public interface IRoleHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IRoleHasRolesCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IRoleHasRolesCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IRoleHasRoleRequestBuilder"/> for the specified group membership.
        /// </summary>
        /// <param name="id">The id (sys_id) for the profile.</param>
        /// <returns>The <see cref="IRoleHasRoleRequestBuilder"/>.</returns>
        IRoleHasRoleRequestBuilder this[string id] { get; }
    }
}
