using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IAttachmentsCollectionRequest.
    /// </summary>
    public partial interface IAttachmentsCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified attachment using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to upload.</param>
        /// <returns>The created attachment.</returns>
        System.Threading.Tasks.Task<Attachment> AddAsync(Attachment attachmentToCreate);

        /// <summary>
        /// Creates the specified User using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created attachment.</returns>
        System.Threading.Tasks.Task<Attachment> AddAsync(Attachment attachmentToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified attachments.
        /// </summary>
        /// <returns>The attachments.</returns>
        System.Threading.Tasks.Task<IAttachmentsCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified attachments.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The attachments collection.</returns>
        System.Threading.Tasks.Task<IAttachmentsCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IAttachmentsCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IAttachmentsCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IAttachmentsCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IAttachmentsCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IAttachmentsCollectionRequest OrderBy(string value);
    }
}
