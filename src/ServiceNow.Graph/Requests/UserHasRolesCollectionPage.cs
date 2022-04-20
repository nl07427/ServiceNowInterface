using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserHasRoles collection
    /// </summary>
    public class UserHasRolesCollectionPage : CollectionPage<UserHasRole>, IUserHasRolesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IUserHasRolesCollectionRequest"/> instance.
        /// </summary>
        public IUserHasRolesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new UserHasRolesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
