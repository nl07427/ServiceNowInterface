using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// GroupHasRolesCollectionRequestBuilder
    /// </summary>
    public class GroupHasRolesCollectionRequestBuilder : BaseRequestBuilder, IGroupHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// GroupHasRolesCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public GroupHasRolesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a roles collection request
        /// </summary>
        /// <returns>IGroupHasRolesCollectionRequest implementation</returns>
        public IGroupHasRolesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a roles (sys_user_role) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IGroupHasRolesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new GroupHasRolesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IGroupHasRoleRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IGroupHasRoleRequestBuilder this[string id] => new GroupHasRoleRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
