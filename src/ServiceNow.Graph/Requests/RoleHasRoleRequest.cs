using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// RoleHasRoleRequest
    /// </summary>
    public class RoleHasRoleRequest : BaseRequest, IRoleHasRoleRequest
    {
        /// <summary>
        /// Constructs a new RoleHasRoleRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public RoleHasRoleRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified rolehasrole using POST.
        /// </summary>
        /// <param name="roleHasRoleToCreate">The rolehasrole to add.</param>
        /// <returns>The added rolehasrole.</returns>
        public System.Threading.Tasks.Task<RoleHasRole> CreateAsync(RoleHasRole roleHasRoleToCreate)
        {
            return CreateAsync(roleHasRoleToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified rolehasrole using POST.
        /// </summary>
        /// <param name="roleHasRoleToCreate">The membership to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The uploaded membership.</returns>
        public async System.Threading.Tasks.Task<RoleHasRole> CreateAsync(RoleHasRole roleHasRoleToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<RoleHasRole>(roleHasRoleToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified rolehasrole.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified rolehasrole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<RoleHasRole>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified rolehasrole.
        /// </summary>
        /// <returns>The rolehasrole entity.</returns>
        public System.Threading.Tasks.Task<RoleHasRole> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified rolehasrole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The rolehasrole (sys_user_role_contains table).</returns>
        public async System.Threading.Tasks.Task<RoleHasRole> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<RoleHasRoleResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="rolehasrole">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public System.Threading.Tasks.Task<RoleHasRole> UpdateAsync(RoleHasRole rolehasrole)
        {
            return UpdateAsync(rolehasrole, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="rolehasrole">The entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated entity.</returns>
        public async System.Threading.Tasks.Task<RoleHasRole> UpdateAsync(RoleHasRole rolehasrole,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<RoleHasRoleResponse>(rolehasrole, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }
        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IRoleHasRoleRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="roleToInitialize">The <see cref="RoleHasRole"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(RoleHasRole roleToInitialize)
        {
        }
    }
}
