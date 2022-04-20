﻿using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CatalogItemOptionMtomRequestBuilder
    /// </summary>
    public class CatalogItemOptionMtomRequestBuilder : EntityRequestBuilder, ICatalogItemOptionMtomRequestBuilder
    {
        /// <summary>
        /// CatalogItemOptionMtomRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CatalogItemOptionMtomRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICatalogItemOptionMtomRequest Request(IEnumerable<Option> options)
        {
            return new CatalogItemOptionMtomRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICatalogItemOptionMtomRequest Request()
        {
            return Request(null);
        }
    }
}
