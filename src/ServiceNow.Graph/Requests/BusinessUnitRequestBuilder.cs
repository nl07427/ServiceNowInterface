using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    public class BusinessUnitRequestBuilder : EntityRequestBuilder, IBusinessUnitRequestBuilder
    {
        /// <summary>
        /// BusinessUnitRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public BusinessUnitRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IBusinessUnitRequest Request(IEnumerable<Option> options)
        {
            return new BusinessUnitRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IBusinessUnitRequest Request()
        {
            return Request(null);
        }
    }
}
