using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserHasRolesCollectionRequest.
    /// </summary>
    public partial interface IUserHasRolesCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified userHasRole using POST.
        /// </summary>
        /// <param name="userHasRole">The userHasRole to create.</param>
        /// <returns>The created userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> AddAsync(UserHasRole userHasRole);

        /// <summary>
        /// Creates the specified userHasRole using POST.
        /// </summary>
        /// <param name="userHasRole">The userHasRole to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created userHasRole.</returns>
        System.Threading.Tasks.Task<UserHasRole> AddAsync(UserHasRole userHasRole, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified roles.
        /// </summary>
        /// <returns>The roles collection.</returns>
        System.Threading.Tasks.Task<IUserHasRolesCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified roles.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The roles collection.</returns>
        System.Threading.Tasks.Task<IUserHasRolesCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IUserHasRolesCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IUserHasRolesCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IUserHasRolesCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IUserHasRolesCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IUserHasRolesCollectionRequest OrderBy(string value);
    }
}
