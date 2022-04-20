using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// OrderGuideRequestBuilder
    /// </summary>
    public class OrderGuideRequestBuilder : EntityRequestBuilder, IOrderGuideRequestBuilder
    {
        /// <summary>
        /// QuestionRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public OrderGuideRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IOrderGuideRequest Request(IEnumerable<Option> options)
        {
            return new OrderGuideRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IOrderGuideRequest Request()
        {
            return Request(null);
        }
    }
}
