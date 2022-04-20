using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IncidentRequestBuilder
    /// </summary>
    public class IncidentRequestBuilder : EntityRequestBuilder, IIncidentRequestBuilder
    {
        /// <summary>
        /// QuestionRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public IncidentRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IIncidentRequest Request(IEnumerable<Option> options)
        {
            return new IncidentRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IIncidentRequest Request()
        {
            return Request(null);
        }
    }
}
