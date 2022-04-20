using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    public interface IBusinessUnitsCollectionPage: ICollectionPage<BusinessUnit>
    {
        /// <summary>
        /// Gets the next page <see cref="IBusinessUnitsCollectionRequest"/> instance.
        /// </summary>
        IBusinessUnitsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
