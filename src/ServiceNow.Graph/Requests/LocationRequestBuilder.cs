using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// LocationRequestBuilder
    /// </summary>
    public class LocationRequestBuilder : EntityRequestBuilder,ILocationRequestBuilder
    {
        /// <summary>
        /// LocationRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public LocationRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ILocationRequest Request(IEnumerable<Option> options)
        {
            return new LocationRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ILocationRequest Request()
        {
            return Request(null);
        }
    }
}
