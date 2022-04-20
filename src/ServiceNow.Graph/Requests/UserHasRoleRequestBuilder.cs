using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserHasRoleRequestBuilder
    /// </summary>
    public class UserHasRoleRequestBuilder : EntityRequestBuilder, IUserHasRoleRequestBuilder
    {
        /// <summary>
        /// UserHasRoleRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public UserHasRoleRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IUserHasRoleRequest Request(IEnumerable<Option> options)
        {
            return new UserHasRoleRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IUserHasRoleRequest Request()
        {
            return Request(null);
        }
    }
}
