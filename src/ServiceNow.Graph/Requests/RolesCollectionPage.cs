using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Roles collection
    /// </summary>
    public class RolesCollectionPage : CollectionPage<Role>, IRolesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IRolesCollectionRequest"/> instance.
        /// </summary>
        public IRolesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new RolesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
