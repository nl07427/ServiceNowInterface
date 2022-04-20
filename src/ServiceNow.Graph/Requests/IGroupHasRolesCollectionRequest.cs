using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IGroupHasRolesCollectionRequest.
    /// </summary>
    public partial interface IGroupHasRolesCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified grouphasrole using POST.
        /// </summary>
        /// <param name="grouphasrole">The grouphasrole to create.</param>
        /// <returns>The created grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> AddAsync(GroupHasRole grouphasrole);

        /// <summary>
        /// Creates the specified grouphasrole using POST.
        /// </summary>
        /// <param name="grouphasrole">The grouphasrole to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created grouphasrole.</returns>
        System.Threading.Tasks.Task<GroupHasRole> AddAsync(GroupHasRole grouphasrole, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified grouphasroles.
        /// </summary>
        /// <returns>The grouphasroles collection.</returns>
        System.Threading.Tasks.Task<IGroupHasRolesCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified grouphasroles.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The grouphasroles collection.</returns>
        System.Threading.Tasks.Task<IGroupHasRolesCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IGroupHasRolesCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IGroupHasRolesCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IGroupHasRolesCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IGroupHasRolesCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        IGroupHasRolesCollectionRequest OrderBy(string value);
    }
}
