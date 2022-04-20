using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRoleRequest.
    /// </summary>
    public partial interface IRoleRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified role using POST.
        /// </summary>
        /// <param name="roleToCreate">The role to create.</param>
        /// <returns>The created role.</returns>
        System.Threading.Tasks.Task<Role> CreateAsync(Role roleToCreate);

        /// <summary>
        /// Creates the specified role using POST.
        /// </summary>
        /// <param name="roleToCreate">The role to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created role.</returns>
        System.Threading.Tasks.Task<Role> CreateAsync(Role roleToCreate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified role entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified role entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified role entity.
        /// </summary>
        /// <returns>The role entity.</returns>
        System.Threading.Tasks.Task<Role> GetAsync();

        /// <summary>
        /// Gets the specified role entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The role entity.</returns>
        System.Threading.Tasks.Task<Role> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified Role using PATCH.
        /// </summary>
        /// <param name="role">The sys_user_role with values to update.</param>
        /// <returns>The updated role.</returns>
        System.Threading.Tasks.Task<Role> UpdateAsync(Role role);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="role">The role with changed values.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated role.</returns>
        System.Threading.Tasks.Task<Role> UpdateAsync(Role role, CancellationToken cancellationToken);
    }
}
