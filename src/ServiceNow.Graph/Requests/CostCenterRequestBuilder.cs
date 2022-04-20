using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CostCenterRequestBuilder
    /// </summary>
    public class CostCenterRequestBuilder : EntityRequestBuilder, ICostCenterRequestBuilder
    {
        /// <summary>
        /// CostCenterRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CostCenterRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICostCenterRequest Request(IEnumerable<Option> options)
        {
            return new CostCenterRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICostCenterRequest Request()
        {
            return Request(null);
        }
    }
}
