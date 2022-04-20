using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserHasRoleRequest.
    /// </summary>
    public partial interface IUserHasRoleRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified userHasRole using POST.
        /// </summary>
        /// <param name="roleToCreate">The userHasRole to create.</param>
        /// <returns>The created userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> CreateAsync(UserHasRole roleToCreate);

        /// <summary>
        /// Creates the specified userHasRole using POST.
        /// </summary>
        /// <param name="roleToCreate">The userHasRole to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> CreateAsync(UserHasRole roleToCreate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified userHasRole entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified userHasRole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified userHasRole entity.
        /// </summary>
        /// <returns>The userHasRole entity.</returns>
        System.Threading.Tasks.Task<UserHasRole> GetAsync();

        /// <summary>
        /// Gets the specified userHasRole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The userHasRole entity.</returns>
        System.Threading.Tasks.Task<UserHasRole> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified UserHasRole using PATCH.
        /// </summary>
        /// <param name="userHasRole">The sys_user_role with values to update.</param>
        /// <returns>The updated userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> UpdateAsync(UserHasRole userHasRole);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="userHasRole">The userHasRole with changed values.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> UpdateAsync(UserHasRole userHasRole, CancellationToken cancellationToken);
    }
}
