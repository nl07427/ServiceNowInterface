using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Attachments collection
    /// </summary>
    public class AttachmentsCollectionPage : CollectionPage<Attachment>, IAttachmentsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IAttachmentsCollectionRequest"/> instance.
        /// </summary>
        public IAttachmentsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new AttachmentsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
