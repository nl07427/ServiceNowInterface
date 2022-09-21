using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    public interface IBuildingCollectionPage: ICollectionPage<Building>
    {
        /// <summary>
        /// Gets the next page <see cref="IBuildingCollectionRequest"/> instance.
        /// </summary>
        IBuildingCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
