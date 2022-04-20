using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemRequestBuilder
    /// </summary>
    public class CatalogItemRequestBuilder : EntityRequestBuilder, ICatalogItemRequestBuilder
    {
        /// <summary>
        /// CatalogItemRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogItemRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICatalogItemRequest Request(IEnumerable<Option> options)
        {
            return new CatalogItemRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICatalogItemRequest Request()
        {
            return Request(null);
        }
    }
}
