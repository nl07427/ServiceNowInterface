using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserGroupRequest.
    /// </summary>
    public partial interface IUserGroupRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified UserGroup using POST.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to create.</param>
        /// <returns>The created UserGroup.</returns>
        System.Threading.Tasks.Task<UserGroup> CreateAsync(UserGroup userGroupToCreate);

        /// <summary>
        /// Creates the specified UserGroup using POST.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created group.</returns>
        System.Threading.Tasks.Task<UserGroup> CreateAsync(UserGroup userGroupToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified UserGroup.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified UserGroup.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified UserGroup.
        /// </summary>
        /// <returns>The UserGroup.</returns>
        System.Threading.Tasks.Task<UserGroup> GetAsync();

        /// <summary>
        /// Gets the specified UserGroup.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The group.</returns>
        System.Threading.Tasks.Task<UserGroup> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified UserGroup using PATCH.
        /// </summary>
        /// <param name="userGroupToCreate">The group update.</param>
        /// <returns>The updated group.</returns>
        System.Threading.Tasks.Task<UserGroup> UpdateAsync(UserGroup userGroupToCreate);

        /// <summary>
        /// Updates the specified UserGroup using PATCH.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated group.</returns>
        System.Threading.Tasks.Task<UserGroup> UpdateAsync(UserGroup userGroupToCreate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupRequest Select(string value);
    }
}
