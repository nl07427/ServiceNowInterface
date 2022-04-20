using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserRequest.
    /// </summary>
    public partial interface IUserRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified User using POST.
        /// </summary>
        /// <param name="userToCreate">The User to create.</param>
        /// <returns>The created User.</returns>
        System.Threading.Tasks.Task<User> CreateAsync(User userToCreate);

        /// <summary>
        /// Creates the specified User using POST.
        /// </summary>
        /// <param name="userToCreate">The User to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created user.</returns>
        System.Threading.Tasks.Task<User> CreateAsync(User userToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified User.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified User.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified User.
        /// </summary>
        /// <returns>The user account.</returns>
        System.Threading.Tasks.Task<User> GetAsync();

        /// <summary>
        /// Gets the specified User.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The user account.</returns>
        System.Threading.Tasks.Task<User> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="userToCreate">The user account update.</param>
        /// <returns>The updated user account.</returns>
        System.Threading.Tasks.Task<User> UpdateAsync(User userToCreate);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="userToCreate">The User to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated user account.</returns>
        System.Threading.Tasks.Task<User> UpdateAsync(User userToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IUserRequest Select(string value);
    }
}
