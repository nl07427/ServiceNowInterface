using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Group memberships collection
    /// </summary>
    public class MembershipsCollectionPage : CollectionPage<UserGroupMembership>, IMembershipsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IMembershipsCollectionRequest"/> instance.
        /// </summary>
        public IMembershipsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new MembershipsCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
