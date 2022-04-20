using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemOptionMtomRequest
    /// </summary>
    public class CatalogItemOptionMtomRequest : BaseRequest, ICatalogItemOptionMtomRequest
    {
        /// <summary>
        /// Constructs a new CatalogItemOptionMtomRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public CatalogItemOptionMtomRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified entity using POST.
        /// </summary>
        /// <param name="entry">The entity to create.</param>
        /// <returns>The created entity.</returns>
        public System.Threading.Tasks.Task<CatalogItemOptionMtom> CreateAsync(CatalogItemOptionMtom entry)
        {
            return CreateAsync(entry, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified entity using POST.
        /// </summary>
        /// <param name="entry">The entity to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entity.</returns>
        public async System.Threading.Tasks.Task<CatalogItemOptionMtom> CreateAsync(CatalogItemOptionMtom entry,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<CatalogItemOptionMtom>(entry, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<CatalogItemOptionMtom>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <returns>The entity.</returns>
        public System.Threading.Tasks.Task<CatalogItemOptionMtom> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The entity (sc_item_option_mtom table).</returns>
        public async System.Threading.Tasks.Task<CatalogItemOptionMtom> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<CatalogItemOptionMtomResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="toUpdate">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public System.Threading.Tasks.Task<CatalogItemOptionMtom> UpdateAsync(CatalogItemOptionMtom toUpdate)
        {
            return UpdateAsync(toUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified entity using PATCH.
        /// </summary>
        /// <param name="toUpdate">The entity to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated entity.</returns>
        public async System.Threading.Tasks.Task<CatalogItemOptionMtom> UpdateAsync(CatalogItemOptionMtom toUpdate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<CatalogItemOptionMtomResponse>(toUpdate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public ICatalogItemOptionMtomRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="toUpdate">The <see cref="CatalogItemOptionMtom"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(CatalogItemOptionMtom toUpdate)
        {
        }
    }
}
