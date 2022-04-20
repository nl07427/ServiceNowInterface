using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// GroupHasRoleRequest
    /// </summary>
    public class GroupHasRoleRequest : BaseRequest, IGroupHasRoleRequest
    {
        /// <summary>
        /// Constructs a new GroupHasRoleRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public GroupHasRoleRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified groupHasRole using POST.
        /// </summary>
        /// <param name="groupHasRoleToCreate">The groupHasRole to add.</param>
        /// <returns>The added groupHasRole.</returns>
        public System.Threading.Tasks.Task<GroupHasRole> CreateAsync(GroupHasRole groupHasRoleToCreate)
        {
            return CreateAsync(groupHasRoleToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified groupHasRole using POST.
        /// </summary>
        /// <param name="groupHasRoleToCreate">The membership to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The uploaded membership.</returns>
        public async System.Threading.Tasks.Task<GroupHasRole> CreateAsync(GroupHasRole groupHasRoleToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<GroupHasRole>(groupHasRoleToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified groupHasRole.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified groupHasRole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<GroupHasRole>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified groupHasRole.
        /// </summary>
        /// <returns>The groupHasRole entity.</returns>
        public System.Threading.Tasks.Task<GroupHasRole> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified groupHasRole.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The groupHasRole (live_profile table).</returns>
        public async System.Threading.Tasks.Task<GroupHasRole> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<GroupHasRoleResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="groupHasRole">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public System.Threading.Tasks.Task<GroupHasRole> UpdateAsync(GroupHasRole groupHasRole)
        {
            return UpdateAsync(groupHasRole, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="groupHasRole">The entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated entity.</returns>
        public async System.Threading.Tasks.Task<GroupHasRole> UpdateAsync(GroupHasRole groupHasRole,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<GroupHasRoleResponse>(groupHasRole, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }
        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IGroupHasRoleRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="groupHasRoleToInitialize">The <see cref="GroupHasRole"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(GroupHasRole groupHasRoleToInitialize)
        {
        }
    }
}
