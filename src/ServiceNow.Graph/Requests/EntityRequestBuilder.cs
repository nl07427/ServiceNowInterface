﻿using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The type EntityRequestBuilder.
    /// </summary>
    public class EntityRequestBuilder : BaseRequestBuilder, IEntityRequestBuilder
    {
        /// <summary>
        /// Constructs a new EntityRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public EntityRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IEntityRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IEntityRequest Request(IEnumerable<Option> options)
        {
            return new EntityRequest(RequestUrl, Client, options);
        }
    }
}
