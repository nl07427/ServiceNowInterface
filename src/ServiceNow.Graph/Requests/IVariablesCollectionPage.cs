using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IVariablesCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<VariablesCollectionPage>))]
    public interface IVariablesCollectionPage : ICollectionPage<Variable>
    {
        /// <summary>
        /// Gets the next page <see cref="IVariablesCollectionRequest"/> instance.
        /// </summary>
        IVariablesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
