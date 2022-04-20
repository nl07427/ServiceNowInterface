using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// AttachmentRequestBuilder
    /// </summary>
    public class AttachmentRequestBuilder : EntityRequestBuilder, IAttachmentRequestBuilder
    {
        /// <summary>
        /// AttachmentRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public AttachmentRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IAttachmentRequest Request(IEnumerable<Option> options)
        {
            return new AttachmentRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IAttachmentRequest Request()
        {
            return Request(null);
        }
    }
}
