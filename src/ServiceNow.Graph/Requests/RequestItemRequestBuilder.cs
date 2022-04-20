using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RequestItemRequestBuilder
    /// </summary>
    public class RequestItemRequestBuilder : EntityRequestBuilder, IRequestItemRequestBuilder
    {
        /// <summary>
        /// RequestItemRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RequestItemRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IRequestItemRequest Request(IEnumerable<Option> options)
        {
            return new RequestItemRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IRequestItemRequest Request()
        {
            return Request(null);
        }
    }
}
