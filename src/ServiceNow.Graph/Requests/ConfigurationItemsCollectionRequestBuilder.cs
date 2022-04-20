using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ConfigurationItemsCollectionRequestBuilder
    /// </summary>
    public class ConfigurationItemsCollectionRequestBuilder :BaseRequestBuilder, IConfigurationItemsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public ConfigurationItemsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IConfigurationItemsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IConfigurationItemsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new ConfigurationItemsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IConfigurationItemRequestBuilder this[string id] => new ConfigurationItemRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
