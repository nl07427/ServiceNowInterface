using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Groups collection
    /// </summary>
    public class UserGroupsCollectionPage : CollectionPage<UserGroup>, IUserGroupsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IUserGroupCollectionRequest"/> instance.
        /// </summary>
        public IUserGroupCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new UserGroupCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
