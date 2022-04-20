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
    /// GroupHasRolesCollectionRequest
    /// </summary>
    public class GroupHasRolesCollectionRequest : BaseRequest, IGroupHasRolesCollectionRequest
    {
        /// <summary>
        /// New GroupHasRolesCollectionRequest object
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public GroupHasRolesCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) :
            base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Adds the specified groupHasRole to the collection via POST.
        /// </summary>
        /// <param name="groupHasRole">The groupHasRole to add</param>
        /// <returns>The created groupHasRole.</returns>
        public async Task<GroupHasRole> AddAsync(GroupHasRole groupHasRole)
        {
            return await AddAsync(groupHasRole, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the specified groupHasRole to the collection via POST.
        /// </summary>
        /// <param name="groupHasRole">The groupHasRole to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created groupHasRole.</returns>
        public async Task<GroupHasRole> AddAsync(GroupHasRole groupHasRole, CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var response = await SendAsync<GroupHasRoleResponse>(groupHasRole, cancellationToken).ConfigureAwait(false);
            return response.Result;
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        public async Task<IGroupHasRolesCollectionPage> GetAsync()
        {
            return await GetAsync(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        public async Task<IGroupHasRolesCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var response = await SendAsync<GroupHasRolesCollectionResponse>(null, cancellationToken)
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
        public IGroupHasRolesCollectionRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", WebUtility.UrlEncode(value)));
            return this;
        }

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        public IGroupHasRolesCollectionRequest Top(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_limit", value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        public IGroupHasRolesCollectionRequest Filter(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_query", WebUtility.UrlEncode(value)));
            return this;
        }

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        public IGroupHasRolesCollectionRequest Skip(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_offset", value.ToString()));
            return this;
        }

        /// <summary>
        /// Order results
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IGroupHasRolesCollectionRequest OrderBy(string value)
        {
            QueryOptions.Add(new QueryOption("ORDERBY", value));
            return this;
        }
    }
}
