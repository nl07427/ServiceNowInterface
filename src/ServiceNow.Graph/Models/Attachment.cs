using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_attachment table, retrieval through the attachment REST API
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Attachment : Entity
    {
        /// <summary>
        /// Size in bytes
        /// </summary>
        [JsonProperty(PropertyName = "size_bytes", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public long? SizeBytes { get; set; }

        /// <summary>
        /// File name, X100
        /// </summary>
        [JsonProperty(PropertyName = "file_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string FileName { get; set; }

        /// <summary>
        /// Average image color, ServiceNow color type
        /// </summary>
        [JsonProperty(PropertyName = "average_image_color", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AverageImageColor { get; set; }

        /// <summary>
        /// Image width
        /// </summary>
        [JsonProperty(PropertyName = "image_width", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? ImageWidth { get; set; }

        /// <summary>
        /// Name of table linked to this attachment
        /// </summary>
        [JsonProperty(PropertyName = "table_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string TableName { get; set; }

        /// <summary>
        /// Image height
        /// </summary>
        [JsonProperty(PropertyName = "image_height", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? ImageHeight { get; set; }

        /// <summary>
        /// Direct download link of the attachment
        /// </summary>
        [JsonProperty(PropertyName = "download_link", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public Uri DownloadLink { get; set; }

        /// <summary>
        /// HTTP Content type
        /// </summary>
        [JsonProperty(PropertyName = "content_type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ContentType { get; set; }

        /// <summary>
        /// Size of attachment when compressed
        /// </summary>
        [JsonProperty(PropertyName = "size_compressed", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? SizeCompressed { get; set; }

        /// <summary>
        /// Compressed flag
        /// </summary>
        [JsonProperty(PropertyName = "compressed", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Compressed { get; set; }

        /// <summary>
        /// Attachment state
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string State { get; set; }

        /// <summary>
        /// Sys_id of the referenced table row
        /// </summary>
        [JsonProperty(PropertyName = "table_sys_id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string TableSysId { get; set; }

        /// <summary>
        /// Chunk size bytes
        /// </summary>
        [JsonProperty(PropertyName = "chunk_size_bytes", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? ChunkSizeBytes { get; set; }

        /// <summary>
        /// Hash value of attachment
        /// </summary>
        [JsonProperty(PropertyName = "hash", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Hash { get; set; }

        /// <summary>
        /// Image base64 encoded
        /// </summary>
        public string Image { get; set; }
    }
}
