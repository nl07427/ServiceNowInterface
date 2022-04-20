using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Requests
{
    public interface IBusinessUnitRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<BusinessUnit> CreateAsync(BusinessUnit entry);

        /// <summary>
        /// Creates the specified entry using POST.
        /// </summary>
        /// <param name="entry">The entry to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entry.</returns>
        System.Threading.Tasks.Task<BusinessUnit> CreateAsync(BusinessUnit entry, CancellationToken cancellationToken);

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
        System.Threading.Tasks.Task<BusinessUnit> GetAsync();

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The entity.</returns>
        System.Threading.Tasks.Task<BusinessUnit> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified Business Unit using PATCH.
        /// </summary>
        /// <param name="businessUnitToUpdate">The user account update.</param>
        /// <returns>The updated business unit.</returns>
        System.Threading.Tasks.Task<BusinessUnit> UpdateAsync(BusinessUnit businessUnitToUpdate);

        /// <summary>
        /// Updates the specified Business Unit using PATCH.
        /// </summary>
        /// <param name="businessUnitToUpdate">The User to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated business unit.</returns>
        System.Threading.Tasks.Task<BusinessUnit> UpdateAsync(BusinessUnit businessUnitToUpdate, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IBusinessUnitRequest Select(string value);
    }
}

