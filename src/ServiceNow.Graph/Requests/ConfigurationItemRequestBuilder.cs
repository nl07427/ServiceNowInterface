using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ConfigurationItemRequestBuilder
    /// </summary>
    public class ConfigurationItemRequestBuilder : EntityRequestBuilder, IConfigurationItemRequestBuilder
    {
        /// <summary>
        /// DepartmentRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public ConfigurationItemRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IConfigurationItemRequest Request(IEnumerable<Option> options)
        {
            return new ConfigurationItemRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IConfigurationItemRequest Request()
        {
            return Request(null);
        }
    }
}
