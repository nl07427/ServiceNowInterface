using System.Collections.Generic;
using System.Threading;
using ServiceNow.Graph.Requests.Middleware.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The graph request context class
    /// </summary>
    public class ServiceNowRequestContext
    {
        /// <summary>
        /// A ClientRequestId property
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// A MiddlewareOptions property
        /// </summary>
        public IDictionary<string, IMiddlewareOption> MiddlewareOptions { get; set; }

        /// <summary>
        /// A CancellationToken property
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// A FeatureUsage property
        /// </summary>
        public FeatureFlag FeatureUsage { get; set; }
    }
}
