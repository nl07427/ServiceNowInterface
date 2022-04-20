using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogTaskRequestBuilder
    /// </summary>
    public class CatalogTaskRequestBuilder : EntityRequestBuilder, ICatalogTaskRequestBuilder
    {
        /// <summary>
        /// CatalogTaskRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogTaskRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICatalogTaskRequest Request(IEnumerable<Option> options)
        {
            return new CatalogTaskRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICatalogTaskRequest Request()
        {
            return Request(null);
        }
    }
}
