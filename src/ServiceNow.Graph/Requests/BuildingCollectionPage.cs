using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Building collection
    /// </summary>
    public class BuildingCollectionPage : CollectionPage<Building>, IBuildingCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IBuildingCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new BuildingCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
