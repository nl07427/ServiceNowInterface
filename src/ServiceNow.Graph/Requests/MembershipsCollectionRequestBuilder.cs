using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// MembershipsCollectionRequestBuilder
    /// </summary>
    public class MembershipsCollectionRequestBuilder : BaseRequestBuilder, IMembershipsCollectionRequestBuilder
    {
        /// <summary>
        /// MembershipsCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public MembershipsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a group memberships collection request
        /// </summary>
        /// <returns>IMembershipsCollectionRequest implementation</returns>
        public IMembershipsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a group memberships (sys_user_grmember) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IMembershipsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new MembershipsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IMembershipRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IMembershipRequestBuilder this[string id] => new MembershipRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
