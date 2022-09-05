using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// AttachmentRequest
    /// </summary>
    public class AttachmentRequest : BaseRequest, IAttachmentRequest
    {
        /// <summary>
        /// Constructs a new AttachmentRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public AttachmentRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified attachment using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to upload.</param>
        /// <returns>The added attachment.</returns>
        public System.Threading.Tasks.Task<Attachment> CreateAsync(Attachment attachmentToCreate)
        {
            return CreateAsync(attachmentToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified attachment using POST.
        /// </summary>
        /// <param name="attachmentToCreate">The attachment to upload.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The uploaded attachment.</returns>
        public async System.Threading.Tasks.Task<Attachment> CreateAsync(Attachment attachmentToCreate,
            CancellationToken cancellationToken)
        {
            ContentType = attachmentToCreate.ContentType;
            Method = "POST";
            QueryOptions.Add(new QueryOption("table_name", attachmentToCreate.TableName));
            QueryOptions.Add(new QueryOption("table_sys_id", attachmentToCreate.TableSysId));
            QueryOptions.Add(new QueryOption("file_name", attachmentToCreate.FileName));
            var inputStream = new MemoryStream(Convert.FromBase64String(attachmentToCreate.Image));
            AppendSegmentToRequestUrl("file");
            var newEntity = await SendAsync<Attachment>(inputStream, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified attachment.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified attachment.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            Method = "DELETE";
            await SendAsync<Attachment>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified attachment.
        /// </summary>
        /// <returns>The attachment entity.</returns>
        public System.Threading.Tasks.Task<Attachment> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified attachment.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The attachment (sys_attachment table).</returns>
        public async System.Threading.Tasks.Task<Attachment> GetAsync(CancellationToken cancellationToken)
        {
            Method = "GET";
            var retrievedEntity = await SendAsync<AttachmentResponse>(null, cancellationToken).ConfigureAwait(false);
            InitializeCollectionProperties(retrievedEntity.Result);
            if (retrievedEntity.Result.DownloadLink == null)
                return retrievedEntity.Result;
            RequestUrl = retrievedEntity.Result.DownloadLink.ToString();
            var imageStream = await SendStreamRequestAsync(null, cancellationToken).ConfigureAwait(false);
            if (imageStream == null) return retrievedEntity.Result;

            retrievedEntity.Result.Image = Convert.ToBase64String(((MemoryStream)imageStream).ToArray());
            return retrievedEntity.Result;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IAttachmentRequest Select(string value)
        {
            QueryOptions.Add(new QueryOption("sysparm_fields", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="attachmentToInitialize">The <see cref="Attachment"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(Attachment attachmentToInitialize)
        {
        }
    }
}
