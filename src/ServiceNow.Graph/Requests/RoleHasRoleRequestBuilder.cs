using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RoleHasRoleRequestBuilder
    /// </summary>
    public class RoleHasRoleRequestBuilder : EntityRequestBuilder, IRoleHasRoleRequestBuilder
    {
        /// <summary>
        /// RoleHasRoleRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RoleHasRoleRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IRoleHasRoleRequest Request(IEnumerable<Option> options)
        {
            return new RoleHasRoleRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IRoleHasRoleRequest Request()
        {
            return Request(null);
        }
    }
}
