﻿using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemOptionMtomsCollectionRequest
    /// </summary>
    public class CatalogItemOptionMtomsCollectionRequest : BaseRequest, ICatalogItemOptionMtomsCollectionRequest
    {
        /// <summary>
        /// New collection request object
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public CatalogItemOptionMtomsCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Adds the specified entity to the collection via POST.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The created entity.</returns>
        public async Task<CatalogItemOptionMtom> AddAsync(CatalogItemOptionMtom entity)
        {
            return await AddAsync(entity, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the specified entity to the collection via POST.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created entity.</returns>
        public async Task<CatalogItemOptionMtom> AddAsync(CatalogItemOptionMtom entity, CancellationToken cancellationToken)
        {
            ContentType = "application/json";
            Method = "POST";
            var response = await SendAsync<CatalogItemOptionMtomResponse>(entity, cancellationToken).ConfigureAwait(false);
            return response.Result;
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        public async Task<ICatalogItemOptionMtomsCollectionPage> GetAsync()
        {
            return await GetAsync(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        public async Task<ICatalogItemOptionMtomsCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var response = await SendAsync<CatalogItemOptionMtomsCollectionResponse>(null, cancellationToken).ConfigureAwait(false);
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
        public ICatalogItemOptionMtomsCollectionRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        public ICatalogItemOptionMtomsCollectionRequest Top(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_limit", value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        public ICatalogItemOptionMtomsCollectionRequest Filter(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_query", value));
            return this;
        }

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        public ICatalogItemOptionMtomsCollectionRequest Skip(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_offset", value.ToString()));
            return this;
        }

        /// <summary>
        /// Order results
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ICatalogItemOptionMtomsCollectionRequest OrderBy(string value)
        {
            QueryOptions.Add(new QueryOption("ORDERBY", value));
            return this;
        }
    }
}
