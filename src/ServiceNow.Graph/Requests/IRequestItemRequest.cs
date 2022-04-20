using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IRequestItemRequest
    /// </summary>
    public interface IRequestItemRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<RequestItem> CreateAsync(RequestItem entry);

        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<RequestItem> CreateAsync(RequestItem entry, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <returns>The entity.</returns>
        System.Threading.Tasks.Task<RequestItem> GetAsync();

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The entity.</returns>
        System.Threading.Tasks.Task<RequestItem> GetAsync(CancellationToken cancellationToken);
    }
}
