using System.Collections.Generic;
using ServiceNow.Graph.Helpers;

namespace ServiceNow.Graph
{
    /// <summary>
    /// Utility class with constants used for interfacing with ServiceNow
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The base URL format for the REST API endpoint.
        /// The first parameter is the host domain, the second parameter is the namespace,
        /// third is the API version, and fourth the API name.
        /// </summary>
        public const string ApiUrlFormatString = "https://{0}/api/{1}/{2}/{3}";

        /// <summary>
        /// The base URL format for the REST API endpoint.
        /// The first parameter is the host domain, the second parameter is the namespace,
        /// third is the API version.
        /// </summary>
        public const string ApiUrlFormatWithNoVersionString = "https://{0}/api/{1}/{2}";

        /// <summary>
        /// The base URL format for the OAuth authentication.
        /// The parameter is the host domain.
        /// </summary>
        public const string OAuthGetTokenFormatString = "https://{0}/oauth_token.do";

        /// <summary>
        /// Maps the prefixes like 'sc_', 'sys_' in front of ServiceNow table names to values used in the
        /// classes used to serialize JSON payloads and responses
        /// </summary>
        internal static readonly SortedDictionary<string, string> SectionMapping =
            new SortedDictionary<string, string>(new DescendingLengthComparer())
            {
                {"item_option_new", "Variables"},
                {"sc_", "Catalog"},
                {"sys_", ""}
            };

        /// <summary>
        /// Encoding constants
        /// </summary>
        public static class Encoding
        {
            /// <summary>
            /// gzip encoding.
            /// </summary>
            public const string GZip = "gzip";
        }

        /// <summary>
        /// Constants used for HTTP property names
        /// </summary>
        public static class HttpPropertyNames
        {
            /// <summary>
            /// The Response Headers string
            /// </summary>
            public const string ResponseHeaders = "responseHeaders";

            /// <summary>
            /// The Status Code string
            /// </summary>
            public const string StatusCode = "statusCode";
        }

        /// <summary>
        /// Header constants.
        /// </summary>
        public static class Headers
        {
            /// <summary>
            /// Authorization bearer.
            /// </summary>
            public const string Bearer = "Bearer";

            /// <summary>
            /// SDK Version header
            /// </summary>
            public const string SdkVersionHeaderName = "SdkVersion";

            /// <summary>
            /// SDK Version header
            /// </summary>
            public const string SdkVersionHeaderValueFormatString = "{0}-{1}.{2}.{3}";

            /// <summary>
            /// Content-Type header
            /// </summary>
            public const string FormUrlEncodedContentType = "application/x-www-form-urlencoded";

            /// <summary>
            /// Feature flag
            /// </summary>
            public const string FeatureFlag = "FeatureFlag";

            /// <summary>
            /// IBM DataPower client id header name
            /// </summary>
            public const string ApiGatewayClientId = "X-IBM-Client-ID";

            /// <summary>
            /// IBM DataPower client secret header name
            /// </summary>
            public const string ApiGatewayClientSecret = "X-IBM-Client-Secret";

            /// <summary>
            /// Client Request Id
            /// </summary>
            public const string ClientRequestId = "client-request-id";

            /// <summary>
            /// Accept header
            /// </summary>
            public const string Accept = "Accept";
        }

        /// <summary>
        /// MimeType constants.
        /// </summary>
        public static class MimeTypeNames
        {
            /// <summary>
            /// MimeTypeNames.Application constants.
            /// </summary>
            public static class Application
            {
                /// <summary>
                /// JSON content type value
                /// </summary>
                public const string Json = "application/json";
            }
        }

        /// <summary>
        /// Serialization constants.
        /// </summary>
        public static class Serialization
        {
            /// <summary>
            /// OData type
            /// </summary>
            public const string ObjectType = "sys_class_name";

            /// <summary>
            /// OData next link
            /// </summary>
            internal const string ODataNextLink = "@nextLink";
        }

        internal const string ModelNameSpace = "BelGroupe.ServiceNow";
    }

    /// <summary>
    /// Constants used for HTTP property names
    /// </summary>
    public static class HttpPropertyNames
    {
        /// <summary>
        /// The Response Headers string
        /// </summary>
        public const string ResponseHeaders = "responseHeaders";

        /// <summary>
        /// The Status Code string
        /// </summary>
        public const string StatusCode = "statusCode";
    }

    internal static class GeneratedErrorConstants
    {
        internal static class Codes
        {
            internal static string NotAllowed = "notAllowed";
        }

        internal static class Messages
        {
            internal static string ResponseObjectUsedForUpdate =
                "Do not use objects returned in a response for updating an object in ServiceNow. " +
                "Create a new {0} object and only set the updated properties on it.";
        }
    }
}
