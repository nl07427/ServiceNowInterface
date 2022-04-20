using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRoleHasRoleRequest.
    /// </summary>
    public partial interface IRoleHasRoleRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified rolehasrole using POST.
        /// </summary>
        /// <param name="roleHasRoleToCreate">The rolehasrole to create.</param>
        /// <returns>The created rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> CreateAsync(RoleHasRole roleHasRoleToCreate);

        /// <summary>
        /// Creates the specified rolehasrole using POST.
        /// </summary>
        /// <param name="roleHasRoleToCreate">The rolehasrole to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> CreateAsync(RoleHasRole roleHasRoleToCreate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified rolehasrole entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified rolehasrole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified rolehasrole entity.
        /// </summary>
        /// <returns>The rolehasrole entity.</returns>
        System.Threading.Tasks.Task<RoleHasRole> GetAsync();

        /// <summary>
        /// Gets the specified rolehasrole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The rolehasrole entity.</returns>
        System.Threading.Tasks.Task<RoleHasRole> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified RoleHasRole using PATCH.
        /// </summary>
        /// <param name="rolehasrole">The sys_user_role_contains with values to update.</param>
        /// <returns>The updated rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> UpdateAsync(RoleHasRole rolehasrole);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="rolehasrole">The rolehasrole with changed values.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> UpdateAsync(RoleHasRole rolehasrole, CancellationToken cancellationToken);
    }
}
