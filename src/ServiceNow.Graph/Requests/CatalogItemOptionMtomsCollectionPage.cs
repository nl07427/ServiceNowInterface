using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemOptionMtomsCollectionPage
    /// </summary>
    public class CatalogItemOptionMtomsCollectionPage : CollectionPage<CatalogItemOptionMtom>, ICatalogItemOptionMtomsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogItemOptionMtomsCollectionRequest"/> instance.
        /// </summary>
        public ICatalogItemOptionMtomsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CatalogItemOptionMtomsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
