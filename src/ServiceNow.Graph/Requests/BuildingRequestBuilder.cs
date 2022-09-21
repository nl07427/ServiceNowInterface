using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    public class BuildingRequestBuilder : EntityRequestBuilder, IBuildingRequestBuilder
    {
        /// <summary>
        /// BuildingRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public BuildingRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IBuildingRequest Request(IEnumerable<Option> options)
        {
            return new BuildingRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IBuildingRequest Request()
        {
            return Request(null);
        }
    }
}
