using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemOptionMtomsCollectionRequestBuilder
    /// </summary>
    public class CatalogItemOptionMtomsCollectionRequestBuilder :BaseRequestBuilder, ICatalogItemOptionMtomsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogItemOptionMtomsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICatalogItemOptionMtomsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICatalogItemOptionMtomsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CatalogItemOptionMtomsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICatalogItemOptionMtomRequestBuilder this[string id] => new CatalogItemOptionMtomRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
