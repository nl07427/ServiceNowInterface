using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IGroupHasRoleRequest.
    /// </summary>
    public partial interface IGroupHasRoleRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified grouphasrole using POST.
        /// </summary>
        /// <param name="groupHasRoleToCreate">The grouphasrole to create.</param>
        /// <returns>The created grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> CreateAsync(GroupHasRole groupHasRoleToCreate);

        /// <summary>
        /// Creates the specified grouphasrole using POST.
        /// </summary>
        /// <param name="groupHasRoleToCreate">The grouphasrole to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> CreateAsync(GroupHasRole groupHasRoleToCreate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified grouphasrole entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified grouphasrole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified grouphasrole entity.
        /// </summary>
        /// <returns>The grouphasrole entity.</returns>
        System.Threading.Tasks.Task<GroupHasRole> GetAsync();

        /// <summary>
        /// Gets the specified grouphasrole entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The grouphasrole entity.</returns>
        System.Threading.Tasks.Task<GroupHasRole> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified GroupHasRole using PATCH.
        /// </summary>
        /// <param name="grouphasrole">The sys_user_role with values to update.</param>
        /// <returns>The updated grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> UpdateAsync(GroupHasRole grouphasrole);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="grouphasrole">The grouphasrole with changed values.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> UpdateAsync(GroupHasRole grouphasrole, CancellationToken cancellationToken);
    }
}
