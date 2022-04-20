using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface ILiveProfileRequest.
    /// </summary>
    public partial interface ILiveProfileRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified profile using POST.
        /// </summary>
        /// <param name="profileToCreate">The profile to create.</param>
        /// <returns>The created profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> CreateAsync(LiveProfile profileToCreate);

        /// <summary>
        /// Creates the specified profile using POST.
        /// </summary>
        /// <param name="profileToCreate">The profile to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> CreateAsync(LiveProfile profileToCreate,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified profile entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified profile entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified profile entity.
        /// </summary>
        /// <returns>The profile entity.</returns>
        System.Threading.Tasks.Task<LiveProfile> GetAsync();

        /// <summary>
        /// Gets the specified profile entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The profile entity.</returns>
        System.Threading.Tasks.Task<LiveProfile> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified LiveProfile using PATCH.
        /// </summary>
        /// <param name="profile">The live_profile with values to update.</param>
        /// <returns>The updated profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> UpdateAsync(LiveProfile profile);

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="profile">The profile with changed values.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated profile.</returns>
        System.Threading.Tasks.Task<LiveProfile> UpdateAsync(LiveProfile profile, CancellationToken cancellationToken);
    }
}
