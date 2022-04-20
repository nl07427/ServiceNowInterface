using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogRequestsCollectionPage
    /// </summary>
    public class CatalogRequestsCollectionPage : CollectionPage<CatalogRequest>, ICatalogRequestsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogOptionsCollectionRequest"/> instance.
        /// </summary>
        public ICatalogRequestsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CatalogRequestsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
