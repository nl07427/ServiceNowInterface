using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow cmn_cost_center table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class CostCenter : Entity
    {
        private DateTimeOffset? _validFrom;
        private DateTimeOffset? _validTo;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CostCenter()
        {
            ObjectType = "cmn_cost_center";
        }
        /// <summary>
        /// Account number, X40
        /// </summary>
        [JsonProperty(PropertyName = "account_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Parent cost center
        /// </summary>
        [JsonProperty(PropertyName = "parent", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Code, X40
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Code { get; set; }

        /// <summary>
        /// Manager, sys_user reference
        /// </summary>
        [JsonProperty(PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Manager { get; set; }

        /// <summary>
        /// Valid from, datetime
        /// </summary>
        [JsonProperty(PropertyName = "valid_from", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? ValidFrom
        {
            get => _validFrom;
            set
            {
                if (value.HasValue)
                {
                    _validFrom = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Valid to, datetime
        /// </summary>
        [JsonProperty(PropertyName = "valid_to", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? ValidTo
        {
            get => _validTo;
            set
            {
                if (value.HasValue)
                {
                    _validTo = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Location, cmn_location reference
        /// </summary>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Sys domain
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Domain
        {
            get; set;
        }

        /// <summary>
        /// Sys domain
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain_path", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DomainPath
        {
            get; set;
        }

    }
}
