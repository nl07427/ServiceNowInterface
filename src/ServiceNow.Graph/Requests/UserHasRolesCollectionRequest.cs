using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserHasRolesCollectionRequest
    /// </summary>
    public class UserHasRolesCollectionRequest : BaseRequest, IUserHasRolesCollectionRequest
    {
        /// <summary>
        /// New UserHasRolesCollectionRequest object
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserHasRolesCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) :
            base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Adds the specified userHasRole to the collection via POST.
        /// </summary>
        /// <param name="userHasRole">The userHasRole to add</param>
        /// <returns>The created userHasRole.</returns>
        public async Task<UserHasRole> AddAsync(UserHasRole userHasRole)
        {
            return await AddAsync(userHasRole, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the specified userHasRole to the collection via POST.
        /// </summary>
        /// <param name="userHasRole">The userHasRole to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created userHasRole.</returns>
        public async Task<UserHasRole> AddAsync(UserHasRole userHasRole, CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var response = await SendAsync<UserHasRoleResponse>(userHasRole, cancellationToken).ConfigureAwait(false);
            return response.Result;
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        public async Task<IUserHasRolesCollectionPage> GetAsync()
        {
            return await GetAsync(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        public async Task<IUserHasRolesCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var response = await SendAsync<UserHasRolesCollectionResponse>(null, cancellationToken)
                .ConfigureAwait(false);
            if (response?.Result?.CurrentPage == null) return null;
            if (response.AdditionalData == null) return response.Result;

            // Copy the additional data collection to the page itself so that information is not lost
            response.Result.AdditionalData = response.AdditionalData;

            response.AdditionalData.TryGetValue("responseHeaders", out var responseHeaders);
            if (!(responseHeaders is JObject jsonObject) || !jsonObject.TryGetValue("Link", out var nextPageLink))
                return response.Result;
            var nextPageLinkString = NextPageLinkString(nextPageLink);
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                response.Result.InitializeNextPageRequest(
                    Client,
                    nextPageLinkString);
            }
            return response.Result;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IUserHasRolesCollectionRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        public IUserHasRolesCollectionRequest Top(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_limit", value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        public IUserHasRolesCollectionRequest Filter(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_query", value));
            return this;
        }

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        public IUserHasRolesCollectionRequest Skip(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_offset", value.ToString()));
            return this;
        }

        /// <summary>
        /// Order results
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IUserHasRolesCollectionRequest OrderBy(string value)
        {
            QueryOptions.Add(new QueryOption("ORDERBY", value));
            return this;
        }
    }
}
