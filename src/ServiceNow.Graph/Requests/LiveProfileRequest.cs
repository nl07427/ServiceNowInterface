using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// LiveProfileRequest
    /// </summary>
    public class LiveProfileRequest : BaseRequest, ILiveProfileRequest
    {
        /// <summary>
        /// Constructs a new LiveProfileRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public LiveProfileRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified profile using POST.
        /// </summary>
        /// <param name="profileToCreate">The profile to add.</param>
        /// <returns>The added profile.</returns>
        public System.Threading.Tasks.Task<LiveProfile> CreateAsync(LiveProfile profileToCreate)
        {
            return CreateAsync(profileToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified profile using POST.
        /// </summary>
        /// <param name="profileToCreate">The membership to profile.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The uploaded profile.</returns>
        public async System.Threading.Tasks.Task<LiveProfile> CreateAsync(LiveProfile profileToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<LiveProfile>(profileToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified profile.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified profile.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<LiveProfile>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified profile.
        /// </summary>
        /// <returns>The profile entity.</returns>
        public System.Threading.Tasks.Task<LiveProfile> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified profile.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The profile (live_profile table).</returns>
        public async System.Threading.Tasks.Task<LiveProfile> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<LiveProfileResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="profile">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public System.Threading.Tasks.Task<LiveProfile> UpdateAsync(LiveProfile profile)
        {
            return UpdateAsync(profile, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="profile">The entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated entity.</returns>
        public async System.Threading.Tasks.Task<LiveProfile> UpdateAsync(LiveProfile profile,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<LiveProfileResponse>(profile, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }
        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public ILiveProfileRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="profileToInitialize">The <see cref="LiveProfile"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(LiveProfile profileToInitialize)
        {
        }
    }
}
