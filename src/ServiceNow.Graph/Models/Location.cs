using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow cmn_location entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Location : Entity
    {
        private DateTimeOffset? _coordinatesRetrievedOn;
        /// <summary>
        /// Constructor
        /// </summary>
        public Location()
        {
            ObjectType = "cmn_location";
        }

        /// <summary>
        /// Country, X40
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// Parent location, reference, X32
        /// </summary>
        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// City, X40
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// Latitude, floating point number, X40
        /// </summary>
        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }

        /// <summary>
        /// Stock room, true/false
        /// </summary>
        [JsonProperty("stock_room", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StockRoom { get; set; }

        /// <summary>
        /// Street, tow line text area, X255
        /// </summary>
        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        /// <summary>
        /// Contact, reference to sys_user, X32
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Contact { get; set; }

        /// <summary>
        /// Phone territory, reference to sys_phone_territory, X32
        /// </summary>
        [JsonProperty("phone_territory", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink PhoneTerritory { get; set; }

        /// <summary>
        /// Company, reference to table company, X32
        /// </summary>
        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Lat long error, X1000
        /// </summary>
        [JsonProperty("lat_long_error", NullValueHandling = NullValueHandling.Ignore)]
        public string LatLongError { get; set; }

        /// <summary>
        /// State/Province, X40
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// Longitude, floating point number, X40
        /// </summary>
        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }

        /// <summary>
        /// Zip/Postal code, X40
        /// </summary>
        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        /// <summary>
        /// Time zone, X40
        /// </summary>
        [JsonProperty("time_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        /// <summary>
        /// Full name, X255
        /// </summary>
        [JsonProperty("full_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        /// <summary>
        /// Fax phone, X40
        /// </summary>
        [JsonProperty("fax_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string FaxPhone { get; set; }

        /// <summary>
        /// Phone, X40
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Name, display, X100
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Primary location, reference to cmn_location, X32
        /// </summary>
        [JsonProperty("primary_location", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink PrimaryLocation
        {
            get; set;
        }

        /// <summary>
        /// Managed by group, reference to sys_user_group, X32
        /// </summary>
        [JsonProperty("managed_by_group", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink ManagedByGroup
        {
            get; set;
        }

        /// <summary>
        /// Life cycle stage, reference
        /// </summary>
        [JsonProperty("life_cycle_stage", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink LifeCycleStage
        {
            get; set;
        }

        /// <summary>
        /// Life cycle stage status, reference
        /// </summary>
        [JsonProperty("life_cycle_stage_status", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink LifeCycleStageStatus
        {
            get; set;
        }

        /// <summary>
        /// Duplicate, true/false
        /// </summary>
        [JsonProperty("duplicate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Duplicate
        {
            get; set;
        }

        /// <summary>
        /// City, X40
        /// </summary>
        [JsonProperty("cmn_location_source", NullValueHandling = NullValueHandling.Ignore)]
        public string CmnLocationSource
        {
            get; set;
        }

        /// <summary>
        /// City, X40
        /// </summary>
        [JsonProperty("cmn_location_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CmnLocationType
        {
            get; set;
        }
        /// <summary>
        /// Coordinates retrieved on, date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "coordinates_retrieved_on", Required = Required.Default)]
        public DateTimeOffset? CoordinatesRetrievedOn
        {
            get => _coordinatesRetrievedOn;
            set
            {
                if (value.HasValue)
                {
                    _coordinatesRetrievedOn = value.Value + value.Value.Offset;
                }
            }
        }


    }
}
