﻿using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogItemsCollectionRequest
    /// </summary>
    public interface ICatalogItemsCollectionRequest : IBaseRequest
    {
        /// <summary>
        /// Adds the specified entity to the collection via POST.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The created entity.</returns>
        System.Threading.Tasks.Task<CatalogItem> AddAsync(CatalogItem entity);

        /// <summary>
        /// Adds the specified entity to the collection via POST.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entity.</returns>
        System.Threading.Tasks.Task<CatalogItem> AddAsync(CatalogItem entity, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<ICatalogItemsCollectionPage> GetAsync();

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        System.Threading.Tasks.Task<ICatalogItemsCollectionPage> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        ICatalogItemsCollectionRequest Select(string value);

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        ICatalogItemsCollectionRequest Top(int value);

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        ICatalogItemsCollectionRequest Filter(string value);

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        ICatalogItemsCollectionRequest Skip(int value);

        /// <summary>
        /// Adds the specified order by value to the request.
        /// </summary>
        /// <param name="value">The order by value.</param>
        /// <returns>The request object to send.</returns>
        ICatalogItemsCollectionRequest OrderBy(string value);
    }
}
