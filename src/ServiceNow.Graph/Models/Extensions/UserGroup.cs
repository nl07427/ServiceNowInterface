using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    public partial class UserGroup
    {

        /// <summary>
        /// Distinguished name, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_dn", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DistinguishedName { get; set; }

        /// <summary>
        /// LDAP Id, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_ldapid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LdapId { get; set; }
    }
}
