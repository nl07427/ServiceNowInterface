namespace ServiceNow.Graph
{
    /// <summary>
    /// Utility class with constants used for interfacing with ServiceNow
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The base URL format for the OAuth authentication.
        /// The parameter is the host domain.
        /// </summary>
        public const string OAuthGetTokenFormatString = "https://{0}/oauth_token.do";

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
    }
}
