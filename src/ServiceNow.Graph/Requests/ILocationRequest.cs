﻿using System.Threading;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ILocationRequest
    /// </summary>
    public interface ILocationRequest
    {
        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<Location> CreateAsync(Location entry);

        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<Location> CreateAsync(Location entry, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <returns>The entity.</returns>
        System.Threading.Tasks.Task<Location> GetAsync();

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The entity.</returns>
        System.Threading.Tasks.Task<Location> GetAsync(CancellationToken cancellationToken);
    }
}
