﻿using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserHasRoleRequestBuilder.
    /// </summary>
    public interface IUserHasRoleRequestBuilder : IEntityRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        new IUserHasRoleRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        new IUserHasRoleRequest Request(IEnumerable<Option> options);
    }
}
