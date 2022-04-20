using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// DepartmentRequestBuilder
    /// </summary>
    public class DepartmentRequestBuilder : EntityRequestBuilder, IDepartmentRequestBuilder
    {
        /// <summary>
        /// DepartmentRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public DepartmentRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IDepartmentRequest Request(IEnumerable<Option> options)
        {
            return new DepartmentRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IDepartmentRequest Request()
        {
            return Request(null);
        }
    }
}
