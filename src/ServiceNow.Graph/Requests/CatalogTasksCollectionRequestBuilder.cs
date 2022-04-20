using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogTasksCollectionRequestBuilder
    /// </summary>
    public class CatalogTasksCollectionRequestBuilder :BaseRequestBuilder, ICatalogTasksCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogTasksCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICatalogTasksCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICatalogTasksCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CatalogTasksCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICatalogTaskRequestBuilder this[string id] => new CatalogTaskRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
