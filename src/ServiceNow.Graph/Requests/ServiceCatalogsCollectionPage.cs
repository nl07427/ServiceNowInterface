using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ServiceCatalogsCollectionPage
    /// </summary>
    public class ServiceCatalogsCollectionPage : CollectionPage<ServiceCatalog>, IServiceCatalogsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IServiceCatalogsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new ServiceCatalogsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
