﻿using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type IncidentsCollectionResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class IncidentsCollectionResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="IIncidentsCollectionPage"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public IIncidentsCollectionPage Result { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
