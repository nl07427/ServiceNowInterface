using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRoleHasRolesCollectionRequest.
    /// </summary>
    public partial interface IRoleHasRolesCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified rolehasrole using POST.
        /// </summary>
        /// <param name="rolehasrole">The rolehasrole to create.</param>
        /// <returns>The created rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> AddAsync(RoleHasRole rolehasrole);

        /// <summary>
        /// Creates the specified rolehasrole using POST.
        /// </summary>
        /// <param name="rolehasrole">The rolehasrole to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created rolehasrole.</returns>
        System.Threading.Tasks.Task<RoleHasRole> AddAsync(RoleHasRole rolehasrole, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified rolehasroles.
        /// </summary>
        /// <returns>The rolehasroles collection.</returns>
        System.Threading.Tasks.Task<IRoleHasRolesCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified rolehasroles.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The rolehasroles collection.</returns>
        System.Threading.Tasks.Task<IRoleHasRolesCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IRoleHasRolesCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IRoleHasRolesCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IRoleHasRolesCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IRoleHasRolesCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IRoleHasRolesCollectionRequest OrderBy(string value);
    }
}
