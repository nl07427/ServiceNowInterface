using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// OrderGuidesCollectionRequestBuilder
    /// </summary>
    public class OrderGuidesCollectionRequestBuilder :BaseRequestBuilder, IOrderGuidesCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public OrderGuidesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IOrderGuidesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IOrderGuidesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new OrderGuidesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IOrderGuideRequestBuilder this[string id] => new OrderGuideRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
