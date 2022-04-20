using System;
using System.Linq;
using System.Net.Http;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Extensions
{
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Adds featureflag to existing header values.
        /// </summary>
        /// <param name="httpClient">The http client to set FeatureUsage header.</param>
        /// <param name="featureFlag">The Feature usage flag to set.</param>
        internal static void SetFeatureFlag(this HttpClient httpClient, FeatureFlag featureFlag)
        {
            // If feature flag header exists, add incoming flag to existing bitfield values and replace existing header with the computed bitfield total.
            if (httpClient.DefaultRequestHeaders.TryGetValues(Constants.Headers.FeatureFlag, out var flags))
            {
                // Add incoming flag to existing feature flag values.
                foreach (string flag in flags)
                    if (Enum.TryParse(Convert.ToInt32(flag, 16).ToString(), out FeatureFlag targetFeatureFlag))
                        featureFlag |= targetFeatureFlag;

                // Remove current header value.
                httpClient.DefaultRequestHeaders.Remove(Constants.Headers.FeatureFlag);
            }

            // Add/Replace new computed bitfield.
            httpClient.DefaultRequestHeaders.Add(Constants.Headers.FeatureFlag, Enum.Format(typeof(FeatureFlag), featureFlag, "x"));
        }

        /// <summary>
        /// Checks if a featureflag existing in the default header values.
        /// </summary>
        /// <param name="httpClient">The http client to set FeatureUsage header.</param>
        /// <param name="featureFlag">The Feature usage flag to check for.</param>
        internal static bool ContainsFeatureFlag(this HttpClient httpClient, FeatureFlag featureFlag)
        {
            if (httpClient.DefaultRequestHeaders.TryGetValues(Constants.Headers.FeatureFlag, out var flags))
            {
                string flag = flags.FirstOrDefault();
                if (Enum.TryParse(Convert.ToInt32(flag, 16).ToString(), out FeatureFlag targetFeatureFlag))
                    return targetFeatureFlag.HasFlag(featureFlag);
            }
            return false;
        }
    }
}
