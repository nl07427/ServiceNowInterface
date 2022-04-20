using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ITasksCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<TasksCollectionPage>))]
    public interface 
        ITasksCollectionPage : ICollectionPage<Task>
    {
        /// <summary>
        /// Gets the next page <see cref="ITasksCollectionRequest"/> instance.
        /// </summary>
        ITasksCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
