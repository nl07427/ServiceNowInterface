using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The class BusinessUnitsCollectionRequestBuilder.
    /// </summary>
    public class BusinessUnitsCollectionRequestBuilder :BaseRequestBuilder, IBusinessUnitsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public BusinessUnitsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IBusinessUnitsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IBusinessUnitsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new BusinessUnitsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IBusinessUnitRequestBuilder this[string id] => new BusinessUnitRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
