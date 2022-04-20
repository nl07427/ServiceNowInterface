using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Roles collection
    /// </summary>
    public class RoleHasRolesCollectionPage : CollectionPage<RoleHasRole>, IRoleHasRolesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IRoleHasRolesCollectionRequest"/> instance.
        /// </summary>
        public IRoleHasRolesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new RoleHasRolesCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
