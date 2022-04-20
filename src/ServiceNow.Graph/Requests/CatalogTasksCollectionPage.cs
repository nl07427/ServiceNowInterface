using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogTasksCollectionPage
    /// </summary>
    public class CatalogTasksCollectionPage : CollectionPage<CatalogTask>, ICatalogTasksCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ICatalogTasksCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CatalogTasksCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
