using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IncidentsCollectionPage
    /// </summary>
    public class IncidentsCollectionPage : CollectionPage<Incident>, IIncidentsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IIncidentsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new IncidentsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
