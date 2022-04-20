using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// QuestionRequestBuilder
    /// </summary>
    public class QuestionRequestBuilder : EntityRequestBuilder, IQuestionRequestBuilder
    {
        /// <summary>
        /// QuestionRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public QuestionRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IQuestionRequest Request(IEnumerable<Option> options)
        {
            return new QuestionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IQuestionRequest Request()
        {
            return Request(null);
        }
    }
}
