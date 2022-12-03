using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// UserGroupCollectionRequest
    /// </summary>
    public class AttachmentsCollectionRequest : BaseRequest, IAttachmentsCollectionRequest
    {
        /// <summary>
        /// New AttachmentsCollectionRequest object
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public AttachmentsCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) :
            base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Adds the specified attachment to the collection via POST.
        /// </summary>
        /// <param name="attachment">The attachment to add</param>
        /// <returns>The created user.</returns>
        public async Task<Attachment> AddAsync(Attachment attachment)
        {
            return await AddAsync(attachment, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the specified attachment to the collection via POST.
        /// </summary>
        /// <param name="attachment">The attachment to add</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created attachment.</returns>
        public async Task<Attachment> AddAsync(Attachment attachment, CancellationToken cancellationToken)
        {
            ContentType = attachment.ContentType;
            Method = "POST";
            QueryOptions.Add(new QueryOption("table_name", attachment.TableName));
            QueryOptions.Add(new QueryOption("table_sys_id", attachment.TableSysId));
            QueryOptions.Add(new QueryOption("file_name", attachment.FileName));
            var inputStream = new MemoryStream(Convert.FromBase64String(attachment.Image));
            AppendSegmentToRequestUrl("file");
            var response = await SendAsync<AttachmentResponse>(inputStream, cancellationToken).ConfigureAwait(false);
            return response.Result;
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <returns>The collection page.</returns>
        public async Task<IAttachmentsCollectionPage> GetAsync()
        {
            return await GetAsync(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the collection page.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The collection page.</returns>
        public async Task<IAttachmentsCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var response = await SendAsync<AttachmentsCollectionResponse>(null, cancellationToken)
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
        public IAttachmentsCollectionRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        public IAttachmentsCollectionRequest Top(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_limit", value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the specified filter value to the request.
        /// </summary>
        /// <param name="value">The filter value.</param>
        /// <returns>The request object to send.</returns>
        public IAttachmentsCollectionRequest Filter(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_query", value));
            return this;
        }

        /// <summary>
        /// Adds the specified skip value to the request.
        /// </summary>
        /// <param name="value">The skip value.</param>
        /// <returns>The request object to send.</returns>
        public IAttachmentsCollectionRequest Skip(int value)
        {
            QueryOptions.Add(new QueryOption("sysparm_offset", value.ToString()));
            return this;
        }

        /// <summary>
        /// Order results
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IAttachmentsCollectionRequest OrderBy(string value)
        {
            QueryOptions.Add(new QueryOption("ORDERBY", value));
            return this;
        }
    }
}
