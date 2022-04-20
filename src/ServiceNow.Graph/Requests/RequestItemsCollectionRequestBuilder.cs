using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RequestItemsCollectionRequestBuilder
    /// </summary>
    public class RequestItemsCollectionRequestBuilder :BaseRequestBuilder, IRequestItemsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public RequestItemsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IRequestItemsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IRequestItemsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new RequestItemsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IRequestItemRequestBuilder this[string id] => new RequestItemRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
