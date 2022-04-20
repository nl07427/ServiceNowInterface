using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICompaniesCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CompaniesCollectionPage>))]
    public interface ICompaniesCollectionPage : ICollectionPage<Company>
    {
        /// <summary>
        /// Gets the next page <see cref="ICompaniesCollectionRequest"/> instance.
        /// </summary>
        ICompaniesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
