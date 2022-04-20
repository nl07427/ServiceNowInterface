using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemsCollectionPage
    /// </summary>
    public class CatalogItemsCollectionPage : CollectionPage<CatalogItem>, ICatalogItemsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ICatalogItemsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CatalogItemsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
