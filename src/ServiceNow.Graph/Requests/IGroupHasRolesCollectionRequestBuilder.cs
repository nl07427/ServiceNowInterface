using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IGroupHasRolesCollectionRequestBuilder
    /// </summary>
    public interface IGroupHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IGroupHasRolesCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IGroupHasRolesCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IGroupHasRoleRequestBuilder"/> for the specified group membership.
        /// </summary>
        /// <param name="id">The id (sys_id) for the sys_group_has_role.</param>
        /// <returns>The <see cref="IGroupHasRoleRequestBuilder"/>.</returns>
        IGroupHasRoleRequestBuilder this[string id] { get; }
    }
}
