using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RolesCollectionRequestBuilder
    /// </summary>
    public class RolesCollectionRequestBuilder : BaseRequestBuilder, IRolesCollectionRequestBuilder
    {
        /// <summary>
        /// RolesCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RolesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a roles collection request
        /// </summary>
        /// <returns>IRolesCollectionRequest implementation</returns>
        public IRolesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a roles (sys_user_role) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IRolesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new RolesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IRoleRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IRoleRequestBuilder this[string id] => new RoleRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
