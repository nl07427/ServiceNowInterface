using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IDepartmentsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<DepartmentsCollectionPage>))]
    public interface IDepartmentsCollectionPage : ICollectionPage<Department>
    {
        /// <summary>
        /// Gets the next page <see cref="IDepartmentsCollectionRequest"/> instance.
        /// </summary>
        IDepartmentsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
