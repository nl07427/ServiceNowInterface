using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type ITestEventDeltaRequest.
    /// </summary>
    public interface ITestEventDeltaRequest : IBaseRequest
    {
        /// <summary>
        /// Adds the specified Event to the collection via POST.
        /// </summary>
        /// <param name="eventsEvent">The Event to add.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created Event.</returns>
        Task<TestEvent> AddAsync(TestEvent eventsEvent, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        Task<ITestEventDeltaCollectionPage> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
