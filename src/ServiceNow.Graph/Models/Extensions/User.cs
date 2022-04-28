using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    public partial class User
    {
        /// <summary>
        /// Can approve amount of
        /// </summary>
        [JsonProperty(PropertyName = "u_approval_threshold", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public double ApprovalThreshold { get; set; }

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
        public string LdapUpdated { get; set; }

        /// <summary>
        /// LDAP Id, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_ldapid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LdapId { get; set; }
    }
}
