using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// AttachmentsCollectionRequestBuilder
    /// </summary>
    public class AttachmentsCollectionRequestBuilder : BaseRequestBuilder, IAttachmentsCollectionRequestBuilder
    {
        /// <summary>
        /// AttachmentsCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public AttachmentsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a attachments collection request
        /// </summary>
        /// <returns>IAttachmentsCollectionRequest implementation</returns>
        public IAttachmentsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a attachments (sys_attachment) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IAttachmentsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new AttachmentsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a IUserRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public IAttachmentRequestBuilder this[string id] => new AttachmentRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
