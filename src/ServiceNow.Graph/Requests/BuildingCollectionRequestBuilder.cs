using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The class BuildingCollectionRequestBuilder.
    /// </summary>
    public class BuildingCollectionRequestBuilder :BaseRequestBuilder, IBuildingCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public BuildingCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IBuildingCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IBuildingCollectionRequest Request(IEnumerable<Option> options)
        {
            return new BuildingCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IBuildingRequestBuilder this[string id] => new BuildingRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
