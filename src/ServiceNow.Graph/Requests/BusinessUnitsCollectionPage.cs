using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Business Units collection
    /// </summary>
    public class BusinessUnitsCollectionPage : CollectionPage<BusinessUnit>, IBusinessUnitsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IBusinessUnitsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new BusinessUnitsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
