using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogOptionsCollectionRequestBuilder
    /// </summary>
    public class CatalogOptionsCollectionRequestBuilder :BaseRequestBuilder, ICatalogOptionsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogOptionsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICatalogOptionsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICatalogOptionsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CatalogOptionsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICatalogOptionsRequestBuilder this[string id] => new CatalogOptionsRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
