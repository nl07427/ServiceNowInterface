using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// LocationsCollectionPage
    /// </summary>
    public class LocationsCollectionPage : CollectionPage<Location>, ILocationsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ILocationsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new LocationsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
