using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IMembershipsCollectionRequest.
    /// </summary>
    public partial interface IMembershipsCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Adds the specified group membership to the collection via POST.
        /// </summary>
        /// <param name="membership">The group membership to add</param>
        /// <returns>The created group membership.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> AddAsync(UserGroupMembership membership);

        /// <summary>
        /// Adds the specified group membership to the collection via POST.
        /// </summary>
        /// <param name="membership">The group membership to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created group membership.</returns>
        System.Threading.Tasks.Task<UserGroupMembership> AddAsync(UserGroupMembership membership, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<IMembershipsCollectionPage> GetAsync();

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<IMembershipsCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        IMembershipsCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        IMembershipsCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        IMembershipsCollectionRequest Skip(int value);
    }
}
