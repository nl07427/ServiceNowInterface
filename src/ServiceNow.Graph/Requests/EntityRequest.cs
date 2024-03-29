﻿using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The type EntityRequest.
    /// </summary>
    public partial class EntityRequest : BaseRequest, IEntityRequest
    {
        /// <summary>
        /// Constructs a new EntityRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public EntityRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified Entity using POST.
        /// </summary>
        /// <param name="entityToCreate">The Entity to create.</param>
        /// <returns>The created Entity.</returns>
        public System.Threading.Tasks.Task<Entity> CreateAsync(Entity entityToCreate)
        {
            return this.CreateAsync(entityToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified Entity using POST.
        /// </summary>
        /// <param name="entityToCreate">The Entity to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created Entity.</returns>
        public async System.Threading.Tasks.Task<Entity> CreateAsync(Entity entityToCreate,
            CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var newEntity = await SendAsync<Entity>(entityToCreate, cancellationToken).ConfigureAwait(false);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified Entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified Entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = "DELETE";
            await this.SendAsync<Entity>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified Entity.
        /// </summary>
        /// <returns>The Entity.</returns>
        public System.Threading.Tasks.Task<Entity> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified Entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The Entity.</returns>
        public async System.Threading.Tasks.Task<Entity> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<Entity>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        /// <summary>
        /// Updates the specified Entity using PATCH.
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update.</param>
        /// <returns>The updated Entity.</returns>
        public System.Threading.Tasks.Task<Entity> UpdateAsync(Entity entityToUpdate)
        {
            return this.UpdateAsync(entityToUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified Entity using PATCH.
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated Entity.</returns>
        public async System.Threading.Tasks.Task<Entity> UpdateAsync(Entity entityToUpdate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity = await SendAsync<Entity>(entityToUpdate, cancellationToken).ConfigureAwait(false);
            return updatedEntity;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IEntityRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }
    }
}
