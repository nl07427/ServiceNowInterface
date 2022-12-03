using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type User.
    /// </summary>
    public partial class TestUser
    {

        ///<summary>
        /// The User constructor
        ///</summary>
        public TestUser()
        {
            this.ODataType = "serviceNow.graph.user";
        }

        /// <summary>
        /// Gets or sets id.
        /// Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id", Required = Required.Default)]
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets @odata.type.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type", Required = Required.Default)]
        public string ODataType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets given name.
        /// The given name (first name) of the user. Supports $filter.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "givenName", Required = Required.Default)]
        public string GivenName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets Display name.
        /// The displayName of the user. Supports $filter.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "displayName", Required = Required.Default)]
        public string DisplayName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets state.
        /// The state or province in the user's address. Supports $filter.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state", Required = Required.Default)]
        public string State
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets surname.
        /// The user's surname (family name or last name). Supports $filter.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "surname", Required = Required.Default)]
        public string Surname
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets eventDeltas.
        /// The user's event deltas. This property is just a testing value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eventDeltas", Required = Required.Default)]
        public ITestEventDeltaCollectionPage EventDeltas
        {
            get; set;
        }

    }
}
