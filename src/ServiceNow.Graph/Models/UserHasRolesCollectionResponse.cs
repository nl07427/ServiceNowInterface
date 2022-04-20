﻿using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type UserHasRolesCollectionResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserHasRolesCollectionResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="IUserHasRolesCollectionPage"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public IUserHasRolesCollectionPage  Result { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
