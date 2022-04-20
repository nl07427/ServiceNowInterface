using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CostCentersCollectionPage
    /// </summary>
    public class CostCentersCollectionPage : CollectionPage<CostCenter>, ICostCentersCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ICostCentersCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CostCentersCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
