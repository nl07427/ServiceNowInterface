using System;
using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UsersCollectionRequestBuilder
    /// </summary>
    public class UsersCollectionRequestBuilder : BaseRequestBuilder, IUsersCollectionRequestBuilder
    {
        /// <summary>
        /// UsersCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public UsersCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
            System.Diagnostics.Debug.WriteLine(requestUrl);
        }

        /// <summary>
        /// Builds a group collection request
        /// </summary>
        /// <returns>IUsersCollectionRequest implementation</returns>
        public IUsersCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a users (sys_user) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IUsersCollectionRequest Request(IEnumerable<Option> options)
        {
            return new UsersCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IUserRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IUserRequestBuilder this[string id] => new UserRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
