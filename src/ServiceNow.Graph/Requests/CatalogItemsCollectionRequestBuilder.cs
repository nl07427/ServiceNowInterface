using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemsCollectionRequestBuilder
    /// </summary>
    public class CatalogItemsCollectionRequestBuilder :BaseRequestBuilder, ICatalogItemsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogItemsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICatalogItemsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICatalogItemsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CatalogItemsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICatalogItemRequestBuilder this[string id] => new CatalogItemRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
