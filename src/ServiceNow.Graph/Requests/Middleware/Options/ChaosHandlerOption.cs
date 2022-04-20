using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ServiceNow.Graph.Requests.Middleware.Options
{
    /// <summary>
    /// The Chaos Hander Option middleware class
    /// </summary>
    public class ChaosHandlerOption : IMiddlewareOption
    {
        /// <summary>
        /// Percentage of responses that will have KnownChaos responses injected, assuming no PlannedChaosFactory is provided
        /// </summary>
        public int ChaosPercentLevel { get; set; } = 10;

        /// <summary>
        /// List of failure responses that potentially could be returned when 
        /// </summary>
        public List<HttpResponseMessage> KnownChaos { get; set; } = null;

        /// <summary>
        /// Function to return chaos response based on current request.  This is used to reproduce detected failure modes.
        /// </summary>
        public Func<HttpRequestMessage, HttpResponseMessage> PlannedChaosFactory { get; set; } = null;
    }
}
