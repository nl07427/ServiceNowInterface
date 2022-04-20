using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CostCentersCollectionRequestBuilder
    /// </summary>
    public class CostCentersCollectionRequestBuilder :BaseRequestBuilder, ICostCentersCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CostCentersCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICostCentersCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICostCentersCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CostCentersCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICostCenterRequestBuilder this[string id] => new CostCenterRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
