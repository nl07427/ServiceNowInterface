using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RoleHasRolesCollectionRequestBuilder
    /// </summary>
    public class RoleHasRolesCollectionRequestBuilder : BaseRequestBuilder, IRoleHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// RoleHasRolesCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RoleHasRolesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a roles collection request
        /// </summary>
        /// <returns>IRoleHasRolesCollectionRequest implementation</returns>
        public IRoleHasRolesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a roles (sys_user_role_contains) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IRoleHasRolesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new RoleHasRolesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IRoleHasRoleRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IRoleHasRoleRequestBuilder this[string id] => new RoleHasRoleRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
