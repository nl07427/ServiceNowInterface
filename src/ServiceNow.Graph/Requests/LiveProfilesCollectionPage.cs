using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Profiles collection
    /// </summary>
    public class LiveProfilesCollectionPage : CollectionPage<LiveProfile>, ILiveProfilesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="ILiveProfilesCollectionRequest"/> instance.
        /// </summary>
        public ILiveProfilesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new LiveProfilesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
