using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// DepartmentsCollectionPage
    /// </summary>
    public class DepartmentsCollectionPage : CollectionPage<Department>, IDepartmentsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IDepartmentsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new DepartmentsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
