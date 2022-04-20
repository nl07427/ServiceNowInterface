using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRolesCollectionRequest.
    /// </summary>
    public partial interface IRolesCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified role using POST.
        /// </summary>
        /// <param name="role">The role to create.</param>
        /// <returns>The created role.</returns>
        System.Threading.Tasks.Task<Role> AddAsync(Role role);

        /// <summary>
        /// Creates the specified role using POST.
        /// </summary>
        /// <param name="role">The role to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created role.</returns>
        System.Threading.Tasks.Task<Role> AddAsync(Role role, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified roles.
        /// </summary>
        /// <returns>The roles collection.</returns>
        System.Threading.Tasks.Task<IRolesCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified roles.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The roles collection.</returns>
        System.Threading.Tasks.Task<IRolesCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IRolesCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IRolesCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IRolesCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IRolesCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IRolesCollectionRequest OrderBy(string value);
    }
}
