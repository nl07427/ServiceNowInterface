using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserGroupsCollectionRequestBuilder
    /// </summary>
    public class UserGroupsCollectionRequestBuilder : BaseRequestBuilder, IUserGroupsCollectionRequestBuilder
    {
        /// <summary>
        /// UserGroupsCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public UserGroupsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a group collection request
        /// </summary>
        /// <returns>IUserGroupCollectionRequest implementation</returns>
        public IUserGroupCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a group collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        /// <returns></returns>
        public IUserGroupCollectionRequest Request(IEnumerable<Option> options)
        {
            return  new UserGroupCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IUserGroupRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IUserGroupRequestBuilder this[string id] => new UserGroupRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
