using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// TaskRequestBuilder
    /// </summary>
    public class TaskRequestBuilder : EntityRequestBuilder, ITaskRequestBuilder
    {
        /// <summary>
        /// TaskRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public TaskRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ITaskRequest Request(IEnumerable<Option> options)
        {
            return new TaskRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ITaskRequest Request()
        {
            return Request(null);
        }
    }
}
