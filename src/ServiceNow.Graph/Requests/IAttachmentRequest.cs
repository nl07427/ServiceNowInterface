using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IAttachmentRequest.
    /// </summary>
    public partial interface IAttachmentRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified attachment using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to create.</param>
        /// <returns>The created attachment.</returns>
        System.Threading.Tasks.Task<Attachment> CreateAsync(Attachment attachmentToCreate);

        /// <summary>
        /// Creates the specified attachment using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created attachment.</returns>
        System.Threading.Tasks.Task<Attachment> CreateAsync(Attachment attachmentToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified attachment entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified attachment entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified attachment entity.
        /// </summary>
        /// <returns>The attachment entity.</returns>
        System.Threading.Tasks.Task<Attachment> GetAsync();

        /// <summary>
        /// Gets the specified attachment entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The attachment entity.</returns>
        System.Threading.Tasks.Task<Attachment> GetAsync(CancellationToken cancellationToken);
    }
}
