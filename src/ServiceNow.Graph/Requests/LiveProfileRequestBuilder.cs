using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// LiveProfileRequestBuilder
    /// </summary>
    public class LiveProfileRequestBuilder : EntityRequestBuilder, ILiveProfileRequestBuilder
    {
        /// <summary>
        /// LiveProfileRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public LiveProfileRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ILiveProfileRequest Request(IEnumerable<Option> options)
        {
            return new LiveProfileRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ILiveProfileRequest Request()
        {
            return Request(null);
        }
    }
}
