using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow live_profile table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class LiveProfile : Entity
    {
        /// <summary>
        /// LiveProfile constructor
        /// </summary>
        public LiveProfile()
        {
            ObjectType = "live_profile";
        }

        /// <summary>
        /// Image
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Image { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        [JsonProperty(PropertyName = "short_description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Document
        /// </summary>
        [JsonProperty(PropertyName = "document", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Document { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        [JsonProperty(PropertyName = "photo", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Photo { get; set; }

        /// <summary>
        /// SysDomainPath
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain_path", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysDomainPath { get; set; }

        /// <summary>
        /// Type (user, team, document, other, group)
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Type { get; set; }

        /// <summary>
        /// FollowerCount
        /// </summary>
        [JsonProperty(PropertyName = "follower_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public long? FollowerCount { get; set; }

        /// <summary>
        /// FollowingCount
        /// </summary>
        [JsonProperty(PropertyName = "following_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public long? FollowingCount { get; set; }

        /// <summary>
        /// JoinedFeed
        /// </summary>
        [JsonProperty(PropertyName = "joined_feed", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? JoinedFeed { get; set; }

        /// <summary>
        /// SysDomain
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SysDomain { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Table
        /// </summary>
        [JsonProperty(PropertyName = "table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Table { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Status { get; set; }
    }
}
