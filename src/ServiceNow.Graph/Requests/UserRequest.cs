using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The type UserRequest.
    /// </summary>
    public partial class UserRequest : BaseRequest, IUserRequest
    {
        /// <summary>
        /// Constructs a new UserRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified user using POST.
        /// </summary>
        /// <param name="userToCreate">The User to create.</param>
        /// <returns>The created user account.</returns>
        public System.Threading.Tasks.Task<User> CreateAsync(User userToCreate)
        {
            return CreateAsync(userToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified user account using POST.
        /// </summary>
        /// <param name="userToCreate">The user account to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created user account.</returns>
        public async System.Threading.Tasks.Task<User> CreateAsync(User userToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<User>(userToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified user account.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified user account.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<User>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified User.
        /// </summary>
        /// <returns>The User.</returns>
        public System.Threading.Tasks.Task<User> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified User.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The User (sys_user table).</returns>
        public async System.Threading.Tasks.Task<User> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<UserResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Updates the specified User using PATCH.
        /// </summary>
        /// <param name="userToCreate">The User to update.</param>
        /// <returns>The updated User account.</returns>
        public System.Threading.Tasks.Task<User> UpdateAsync(User userToCreate)
        {
            return UpdateAsync(userToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified User account using PATCH.
        /// </summary>
        /// <param name="userToCreate">The User to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object.</exception>
        /// <returns>The updated user account.</returns>
        public async System.Threading.Tasks.Task<User> UpdateAsync(User userToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "PATCH";
            var updatedEntity =
                await SendAsync<UserResponse>(userToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(updatedEntity.Result);
            return updatedEntity.Result;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IUserRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="userToInitialize">The <see cref="User"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(User userToInitialize)
        {
        }
    }
}
