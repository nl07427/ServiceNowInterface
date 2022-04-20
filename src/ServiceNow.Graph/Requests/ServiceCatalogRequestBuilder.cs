using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ServiceCatalogRequestBuilder
    /// </summary>
    public class ServiceCatalogRequestBuilder : EntityRequestBuilder, IServiceCatalogRequestBuilder
    {
        /// <summary>
        /// QuestionRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public ServiceCatalogRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IServiceCatalogRequest Request(IEnumerable<Option> options)
        {
            return new ServiceCatalogRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IServiceCatalogRequest Request()
        {
            return Request(null);
        }
    }
}
