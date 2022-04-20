using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// VariableRequestBuilder
    /// </summary>
    public class VariableRequestBuilder : EntityRequestBuilder, IVariableRequestBuilder
    {
        /// <summary>
        /// VariableRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public VariableRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IVariableRequest Request(IEnumerable<Option> options)
        {
            return new VariableRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IVariableRequest Request()
        {
            return Request(null);
        }
    }
}
