using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ServiceCatalogsCollectionRequestBuilder
    /// </summary>
    public class ServiceCatalogsCollectionRequestBuilder :BaseRequestBuilder, IServiceCatalogsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public ServiceCatalogsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IServiceCatalogsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IServiceCatalogsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new ServiceCatalogsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IServiceCatalogRequestBuilder this[string id] => new ServiceCatalogRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
