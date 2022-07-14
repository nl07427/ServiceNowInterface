using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    public partial class User
    {
        private DateTimeOffset? _lastLdapUpdate;
        /// <summary>
        /// Can approve amount of
        /// </summary>
        [JsonProperty(PropertyName = "u_approval_threshold", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ApprovalThreshold { get; set; }

        /// <summary>
        /// Division, X40
        /// </summary>
        [JsonProperty(PropertyName = "u_division", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Division { get; set; }

        /// <summary>
        /// Distinguished name, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_dn", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DistinguishedName { get; set; }

        /// <summary>
        /// Last LDAP Update on
        /// </summary>
        [JsonProperty(PropertyName = "u_last_ldap_updated", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? LdapUpdated
        {
            get => _lastLdapUpdate;
            set
            {
                if (value.HasValue)
                {
                    _lastLdapUpdate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// LDAP Id, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_ldapid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LdapId { get; set; }
    }
}
