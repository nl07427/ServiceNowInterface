using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// OrderGuidesCollectionPage
    /// </summary>
    public class OrderGuidesCollectionPage : CollectionPage<OrderGuide>, IOrderGuidesCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IOrderGuidesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new OrderGuidesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
