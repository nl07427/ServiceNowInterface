﻿using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The type UserGroupRequest.
    /// </summary>
    public partial class UserGroupRequest : BaseRequest, IUserGroupRequest
    {
        /// <summary>
        /// Constructs a new UserGroupRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserGroupRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified UserGroup using POST.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to create.</param>
        /// <returns>The created UserGroup.</returns>
        public System.Threading.Tasks.Task<UserGroup> CreateAsync(UserGroup userGroupToCreate)
        {
            return CreateAsync(userGroupToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified UserGroup using POST.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created UserGroup.</returns>
        public async System.Threading.Tasks.Task<UserGroup> CreateAsync(UserGroup userGroupToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<UserGroup>(userGroupToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified UserGroup.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified UserGroup.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<UserGroup>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified UserGroup.
        /// </summary>
        /// <returns>The UserGroup.</returns>
        public System.Threading.Tasks.Task<UserGroup> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified UserGroup.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The UserGroup.</returns>
        public async System.Threading.Tasks.Task<UserGroup> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<UserGroupResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified UserGroup using PATCH.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to update.</param>
        /// <returns>The updated UserGroup.</returns>
        public System.Threading.Tasks.Task<UserGroup> UpdateAsync(UserGroup userGroupToCreate)
        {
            return UpdateAsync(userGroupToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified UserGroup using PATCH.
        /// </summary>
        /// <param name="userGroupToCreate">The UserGroup to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated UserGroup.</returns>
        public async System.Threading.Tasks.Task<UserGroup> UpdateAsync(UserGroup userGroupToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<UserGroupResponse>(userGroupToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IUserGroupRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="userGroupToInitialize">The <see cref="UserGroup"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(UserGroup userGroupToInitialize)
        {
        }
    }
}
