using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IEntityRequest.
    /// </summary>
    public partial interface IEntityRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified Entity using POST.
        /// </summary>
        /// <param name="entityToCreate">The Entity to create.</param>
        /// <returns>The created Entity.</returns>
        System.Threading.Tasks.Task<Entity> CreateAsync(Entity entityToCreate);

        /// <summary>
        /// Creates the specified Entity using POST.
        /// </summary>
        /// <param name="entityToCreate">The Entity to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created Entity.</returns>
        System.Threading.Tasks.Task<Entity> CreateAsync(Entity entityToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified Entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified Entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified Entity.
        /// </summary>
        /// <returns>The Entity.</returns>
        System.Threading.Tasks.Task<Entity> GetAsync();

        /// <summary>
        /// Gets the specified Entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The Entity.</returns>
        System.Threading.Tasks.Task<Entity> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified Entity using PATCH.
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update.</param>
        /// <returns>The updated Entity.</returns>
        System.Threading.Tasks.Task<Entity> UpdateAsync(Entity entityToUpdate);

        /// <summary>
        /// Updates the specified Entity using PATCH.
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated Entity.</returns>
        System.Threading.Tasks.Task<Entity> UpdateAsync(Entity entityToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IEntityRequest Select(string value);
    }
}
