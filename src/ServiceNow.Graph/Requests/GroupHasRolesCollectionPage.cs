using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// GroupHasRoles collection
    /// </summary>
    public class GroupHasRolesCollectionPage : CollectionPage<GroupHasRole>, IGroupHasRolesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IGroupHasRolesCollectionRequest"/> instance.
        /// </summary>
        public IGroupHasRolesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new GroupHasRolesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
