using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogOptionsCollectionPage
    /// </summary>
    public class CatalogOptionsCollectionPage : CollectionPage<CatalogOptions>, ICatalogOptionsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogOptionsCollectionRequest"/> instance.
        /// </summary>
        public ICatalogOptionsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CatalogOptionsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
