using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserHasRolesCollectionRequestBuilder
    /// </summary>
    public class UserHasRolesCollectionRequestBuilder : BaseRequestBuilder, IUserHasRolesCollectionRequestBuilder
    {
        /// <summary>
        /// UserHasRolesCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public UserHasRolesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a userHasRoles collection request
        /// </summary>
        /// <returns>IUserHasRolesCollectionRequest implementation</returns>
        public IUserHasRolesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a userHasRoles (sys_user_role) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IUserHasRolesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new UserHasRolesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IUserHasRoleRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IUserHasRoleRequestBuilder this[string id] => new UserHasRoleRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
