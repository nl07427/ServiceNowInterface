using System.Collections.Generic;
using System.Net;
using System.Threading;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The class MembershipRequest.
    /// </summary>
    public class MembershipRequest : BaseRequest, IMembershipRequest
    {
        /// <summary>
        /// Constructs a new MembershipRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public MembershipRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified membership using POST.
        /// </summary>
        /// <param name="membershipToCreate">The membership to create.</param>
        /// <returns>The created group membership.</returns>
        public System.Threading.Tasks.Task<UserGroupMembership> CreateAsync(UserGroupMembership membershipToCreate)
        {
            return CreateAsync(membershipToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified user account using POST.
        /// </summary>
        /// <param name="membershipToCreate">The group membership to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created group membership.</returns>
        public async System.Threading.Tasks.Task<UserGroupMembership> CreateAsync(UserGroupMembership membershipToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var newEntity = await SendAsync<UserGroupMembership>(membershipToCreate, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified group membership.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified group membership.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<UserGroupMembership>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified group membership entity.
        /// </summary>
        /// <returns>The group membership entity.</returns>
        public System.Threading.Tasks.Task<UserGroupMembership> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified group membership entity.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The group membership (sys_user grmember).</returns>
        public async System.Threading.Tasks.Task<UserGroupMembership> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<MembershipResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="membershipToInitialize">The <see cref="UserGroupMembership"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(UserGroupMembership membershipToInitialize)
        {
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IMembershipRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", WebUtility.UrlEncode(value)));
            return this;
        }

    }
}
