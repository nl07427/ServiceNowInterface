using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RoleRequestBuilder
    /// </summary>
    public class RoleRequestBuilder : EntityRequestBuilder, IRoleRequestBuilder
    {
        /// <summary>
        /// RoleRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RoleRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IRoleRequest Request(IEnumerable<Option> options)
        {
            return new RoleRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IRoleRequest Request()
        {
            return Request(null);
        }
    }
}
