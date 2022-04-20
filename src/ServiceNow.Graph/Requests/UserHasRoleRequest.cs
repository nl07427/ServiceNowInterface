using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserHasRoleRequest
    /// </summary>
    public class UserHasRoleRequest : BaseRequest, IUserHasRoleRequest
    {
        /// <summary>
        /// Constructs a new UserHasRoleRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserHasRoleRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified userHasRole using POST.
        /// </summary>
        /// <param name="userHasRoleToCreate">The userHasRole to add.</param>
        /// <returns>The added userHasRole.</returns>
        public System.Threading.Tasks.Task<UserHasRole> CreateAsync(UserHasRole userHasRoleToCreate)
        {
            return CreateAsync(userHasRoleToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified userHasRole using POST.
        /// </summary>
        /// <param name="userHasRoleToCreate">The membership to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The uploaded membership.</returns>
        public async System.Threading.Tasks.Task<UserHasRole> CreateAsync(UserHasRole userHasRoleToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<UserHasRole>(userHasRoleToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified userHasRole.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified userHasRole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<UserHasRole>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified userHasRole.
        /// </summary>
        /// <returns>The userHasRole entity.</returns>
        public System.Threading.Tasks.Task<UserHasRole> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified userHasRole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The userHasRole (live_profile table).</returns>
        public async System.Threading.Tasks.Task<UserHasRole> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<UserHasRoleResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="userHasRole">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public System.Threading.Tasks.Task<UserHasRole> UpdateAsync(UserHasRole userHasRole)
        {
            return UpdateAsync(userHasRole, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="userHasRole">The entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated entity.</returns>
        public async System.Threading.Tasks.Task<UserHasRole> UpdateAsync(UserHasRole userHasRole,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<UserHasRoleResponse>(userHasRole, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }
        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IUserHasRoleRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="userHasRoleToInitialize">The <see cref="UserHasRole"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(UserHasRole userHasRoleToInitialize)
        {
        }
    }
}
