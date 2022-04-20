using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserGroupCollectionRequest.
    /// </summary>
    public partial interface IUserGroupCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Adds the specified User to the collection via POST.
        /// </summary>
        /// <param name="userGroup">The group to add</param>
        /// <returns>The created group.</returns>
        System.Threading.Tasks.Task<UserGroup> AddAsync(UserGroup userGroup);

        /// <summary>
        /// Adds the specified UserGroup to the collection via POST.
        /// </summary>
        /// <param name="userGroup">The group to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created group.</returns>
        System.Threading.Tasks.Task<UserGroup> AddAsync(UserGroup userGroup, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<IUserGroupsCollectionPage> GetAsync();

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<IUserGroupsCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IUserGroupCollectionRequest OrderBy(string value);
    }
}
