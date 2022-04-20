using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogRequestsCollectionRequestBuilder
    /// </summary>
    public class CatalogRequestsCollectionRequestBuilder :BaseRequestBuilder, ICatalogRequestsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogRequestsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICatalogRequestsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICatalogRequestsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CatalogRequestsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICatalogRequestRequestBuilder this[string id] => new CatalogRequestRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
