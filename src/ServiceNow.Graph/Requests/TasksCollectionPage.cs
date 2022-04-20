using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// TasksCollectionPage
    /// </summary>
    public class TasksCollectionPage : CollectionPage<Task>, ITasksCollectionPage
    {
        /// <summary>
        /// Gets the next page collection request instance.
        /// </summary>
        public ITasksCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                NextPageRequest = new TasksCollectionRequest(
                    nextPageLinkString,
                    client);
            }
        }
    }
}
