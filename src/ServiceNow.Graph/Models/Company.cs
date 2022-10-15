using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow Company (core_company) entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Company : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Company()
        {
            ObjectType = "core_company";
        }

        /// <summary>
        /// Apple icon, X40
        /// </summary>
        [JsonProperty(PropertyName = "apple_icon", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AppleIcon { get; set; }

        /// <summary>
        /// Banner image, X40
        /// </summary>
        [JsonProperty(PropertyName = "banner_image", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string BannerImage { get; set; }

        /// <summary>
        /// UI16 Banner Image, X40
        /// </summary>
        [JsonProperty(PropertyName = "banner_image_light", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string BannerImageLight { get; set; }

        /// <summary>
        /// Banner text, X4000
        /// </summary>
        [JsonProperty("banner_text", NullValueHandling = NullValueHandling.Ignore)]
        public string BannerText { get; set; }

        /// <summary>
        /// City, X50
        /// </summary>
        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string City { get; set; }
        
        /// <summary>
        /// Contact, reference sys_user
        /// </summary>
        [JsonProperty(PropertyName = "contact", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Contact { get; set; }

        /// <summary>
        /// Coordinates retrieved on, date.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "coordinates_retrieved_on", Required = Required.Default)]
        public string CoordinatesRetrievedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Country, X40, default value is USA
        /// </summary>
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Country { get; set; }

        /// <summary>
        /// Customer, bool
        /// </summary>
        [JsonProperty(PropertyName = "customer", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Customer { get; set; }

        /// <summary>
        /// Discount, X15
        /// </summary>
        [JsonProperty(PropertyName = "discount", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Discount { get; set; }

        /// <summary>
        /// Fax phone, X40
        /// </summary>
        [JsonProperty(PropertyName = "fax_phone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string FaxPhone { get; set; }

        /// <summary>
        /// Fiscal year, date but X40 in database
        /// </summary>
        [JsonProperty(PropertyName = "fiscal_year", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string FiscalYear 
        {
            get;
            set;
        }

        /// <summary>
        /// Latitude, X40
        /// </summary>
        [JsonProperty(PropertyName = "latitude", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Latitude { get; set; }

        /// <summary>
        /// Lat long error, X1000
        /// </summary>
        [JsonProperty(PropertyName = "lat_long_error", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LatLongError { get; set; }

        /// <summary>
        /// Longitude, X40
        /// </summary>
        [JsonProperty(PropertyName = "longitude", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Longitude { get; set; }

        /// <summary>
        /// Manufacturer, bool
        /// </summary>
        [JsonProperty(PropertyName = "manufacturer", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Manufacturer { get; set; }

        /// <summary>
        /// Market cap, X20
        /// </summary>
        [JsonProperty(PropertyName = "market_cap", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MarketCap { get; set; }

        /// <summary>
        /// Name, X80
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Notes, X4000
        /// </summary>
        [JsonProperty(PropertyName = "notes", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Notes { get; set; }

        /// <summary>
        /// Number of employees, integer
        /// </summary>
        [JsonProperty("num_employees", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumEmployees { get; set; }

        /// <summary>
        /// Parent, reference to core_|company
        /// </summary>
        [JsonProperty(PropertyName = "parent", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Phone, X40
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Phone { get; set; }

        /// <summary>
        /// Primary, bool
        /// </summary>
        [JsonProperty(PropertyName = "primary", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Primary { get; set; }

        /// <summary>
        /// Profits, X20
        /// </summary>
        [JsonProperty(PropertyName = "profits", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Profits { get; set; }

        /// <summary>
        /// Publicly traded, bool
        /// </summary>
        [JsonProperty(PropertyName = "publicly_traded", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? PubliclyTraded { get; set; }

        /// <summary>
        /// Rank tier, X40
        /// </summary>
        [JsonProperty(PropertyName = "rank_tier", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RankTier { get; set; }

        /// <summary>
        /// Revenue per year, X20
        /// </summary>
        [JsonProperty(PropertyName = "revenue_per_year", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RevenuePerYear { get; set; }

        /// <summary>
        /// State / Province, X40
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string State { get; set; }

        /// <summary>
        /// Stock price, X40
        /// </summary>
        [JsonProperty(PropertyName = "stock_price", NullValueHandling = NullValueHandling.Ignore, Required=Required.Default)]
        public string StockPrice { get; set; }

        /// <summary>
        /// Stock symbol, X40
        /// </summary>
        [JsonProperty(PropertyName = "stock_symbol", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string StockSymbol { get; set; }

        /// <summary>
        /// Street, Two line Text area, X255
        /// </summary>
        [JsonProperty(PropertyName = "street", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Street { get; set; }

        /// <summary>
        /// Theme, reference to sys_ui_theme
        /// </summary>
        [JsonProperty(PropertyName = "theme", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Theme { get; set; }

        /// <summary>
        /// Vendor, bool
        /// </summary>
        [JsonProperty(PropertyName = "vendor", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Vendor { get; set; }

        /// <summary>
        /// Vendor manager, List, X4000
        /// </summary>
        [JsonProperty(PropertyName = "vendor_manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string VendorManager { get; set; }

        /// <summary>
        /// Vendor type, X1024
        /// </summary>
        [JsonProperty(PropertyName = "vendor_type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string VendorType { get; set; }

        /// <summary>
        /// Website, X1024
        /// </summary>
        [JsonProperty(PropertyName = "website", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Website { get; set; }

        /// <summary>
        /// Zip / Postal code, X40
        /// </summary>
        [JsonProperty(PropertyName = "zip", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Zip { get; set; }
    }
}
