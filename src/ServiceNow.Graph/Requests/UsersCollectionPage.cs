using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Users collection
    /// </summary>
    public class UsersCollectionPage : CollectionPage<User>, IUsersCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IUsersCollectionRequest"/> instance.
        /// </summary>
        public IUsersCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new UsersCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
