using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserGroupRequestBuilder
    /// </summary>
    public class UserGroupRequestBuilder : EntityRequestBuilder, IUserGroupRequestBuilder
    {
        /// <summary>
        /// UserGroupRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public UserGroupRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IUserGroupRequest Request(IEnumerable<Option> options)
        {
            return new UserGroupRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IUserGroupRequest Request()
        {
            return Request(null);
        }
    }
}
