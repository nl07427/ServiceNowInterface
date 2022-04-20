using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IUserHasRolesCollectionRequestBuilder
    /// </summary>
    public interface IUserHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IUserHasRolesCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IUserHasRolesCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IUserHasRoleRequestBuilder"/> for the specified group membership.
        /// </summary>
        /// <param name="id">The id (sys_id) for the sys_user_has_role.</param>
        /// <returns>The <see cref="IUserHasRoleRequestBuilder"/>.</returns>
        IUserHasRoleRequestBuilder this[string id] { get; }
    }
}
