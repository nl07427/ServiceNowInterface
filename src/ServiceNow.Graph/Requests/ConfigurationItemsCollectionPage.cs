using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ConfigurationItemsCollectionPage
    /// </summary>
    public class ConfigurationItemsCollectionPage : CollectionPage<ConfigurationItem>, IConfigurationItemsCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public IConfigurationItemsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new ConfigurationItemsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
