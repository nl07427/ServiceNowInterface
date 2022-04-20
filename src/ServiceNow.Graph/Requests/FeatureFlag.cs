using System;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Feature Flags
    /// </summary>
    [Flags]
    public enum FeatureFlag
    {
        /// <summary>
        /// None set
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Redirect Handler
        /// </summary>
        RedirectHandler = 0x00000001,

        /// <summary>
        /// Retry Handler
        /// </summary>
        RetryHandler = 0x00000002,

        /// <summary>
        /// Auth Handler
        /// </summary>
        AuthHandler = 0x00000004,

        /// <summary>
        /// Default Handler
        /// </summary>
        DefaultHttpProvider = 0x00000008,

        /// <summary>
        /// Logging Handler
        /// </summary>
        LoggingHandler = 0x00000010,

        /// <summary>
        /// Service Discovery Handler
        /// </summary>
        ServiceDiscoveryHandler = 0x00000020,

        /// <summary>
        /// Compression Handler
        /// </summary>
        CompressionHandler = 0x00000040,

        ///<summary>
        /// Connection Pool Manager
        /// </summary>
        ConnectionPoolManager = 0x00000080,

        ///<summary>
        /// Long Running Operation Handler
        /// </summary>
        LongRunningOperationHandler = 0x00000100,

        /// <summary>
        /// Batch Request Content Used
        /// </summary>
        BatchRequestContext = 0x00000200,

        /// <summary>
        /// Page Iterator task Used
        /// </summary>
        PageIteratorTask = 0x00000400,

        /// File Upload task Used
        FileUploadTask = 0x00000800
    }
}
