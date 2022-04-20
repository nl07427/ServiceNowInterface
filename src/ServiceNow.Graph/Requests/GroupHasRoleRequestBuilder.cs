using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// GroupHasRoleRequestBuilder
    /// </summary>
    public class GroupHasRoleRequestBuilder : EntityRequestBuilder, IGroupHasRoleRequestBuilder
    {
        /// <summary>
        /// GroupHasRoleRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public GroupHasRoleRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IGroupHasRoleRequest Request(IEnumerable<Option> options)
        {
            return new GroupHasRoleRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IGroupHasRoleRequest Request()
        {
            return Request(null);
        }
    }
}
