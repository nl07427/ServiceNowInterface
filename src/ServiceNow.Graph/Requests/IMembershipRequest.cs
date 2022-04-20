using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IMembershipRequest.
    /// </summary>
    public partial interface IMembershipRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified group membership using POST.
        /// </summary>
        /// <param name="membership">The User to create.</param>
        /// <returns>The created User.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> CreateAsync(UserGroupMembership membership);

        /// <summary>
        /// Creates the specified group membership using POST.
        /// </summary>
        /// <param name="membership">The membership to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created group membership.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> CreateAsync(UserGroupMembership membership, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified group membership entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified group membership entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified group membership entity.
        /// </summary>
        /// <returns>The group membership entity.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> GetAsync();

        /// <summary>
        /// Gets the specified group membership entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The group membership entity.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> GetAsync(CancellationToken cancellationToken);
    }
}
