using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CompaniesCollectionPage
    /// </summary>
    public class CompaniesCollectionPage : CollectionPage<Company>, ICompaniesCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ICompaniesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new CompaniesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
