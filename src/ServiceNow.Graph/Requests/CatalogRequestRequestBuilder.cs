using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogRequestRequestBuilder
    /// </summary>
    public class CatalogRequestRequestBuilder : EntityRequestBuilder, ICatalogRequestRequestBuilder
    {
        /// <summary>
        /// CatalogRequestRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogRequestRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICatalogRequestRequest Request(IEnumerable<Option> options)
        {
            return new CatalogRequestRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICatalogRequestRequest Request()
        {
            return Request(null);
        }
    }
}
