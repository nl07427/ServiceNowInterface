﻿using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type RequestItemsCollectionResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]

    public class RequestItemsCollectionResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="IRequestItemsCollectionPage"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public IRequestItemsCollectionPage Result { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
