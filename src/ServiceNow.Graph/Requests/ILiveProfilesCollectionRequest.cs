using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface ILiveProfilesCollectionRequest.
    /// </summary>
    public partial interface ILiveProfilesCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified profile using POST.
        /// </summary>
        /// <param name="profile">The profile to create.</param>
        /// <returns>The created profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> AddAsync(LiveProfile profile);

        /// <summary>
        /// Creates the specified profile using POST.
        /// </summary>
        /// <param name="profile">The profile to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> AddAsync(LiveProfile profile, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified profiles.
        /// </summary>
        /// <returns>The profiles collection.</returns>
        System.Threading.Tasks.Task<ILiveProfilesCollectionPage> GetAsync();

        /// <summary>
        /// Gets the specified profiles.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The profiles collection.</returns>
        System.Threading.Tasks.Task<ILiveProfilesCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        ILiveProfilesCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        ILiveProfilesCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        ILiveProfilesCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        ILiveProfilesCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        ILiveProfilesCollectionRequest OrderBy(string value);
    }
}
