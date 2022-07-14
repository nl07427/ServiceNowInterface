using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Requests.Middleware;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ServiceNowClientFactory class to create the HTTP client
    /// </summary>
    public static class ServiceNowClientFactory
    {
        /// <summary>
        /// The key for the SDK version header.
        /// </summary>
        private const string SdkVersionHeaderName = Constants.Headers.SdkVersionHeaderName;

        /// <summary>
        /// The version for current assembly.
        /// </summary>
        private static readonly Version AssemblyVersion =
            typeof(ServiceNowClientFactory).GetTypeInfo().Assembly.GetName().Version;

        /// <summary>
        /// The value for the SDK version header.
        /// </summary>
        private static readonly string SdkVersionHeaderValue = string.Format(
            Constants.Headers.SdkVersionHeaderValueFormatString,
            "ServiceNowRestApi",
            AssemblyVersion.Major,
            AssemblyVersion.Minor,
            AssemblyVersion.Build);

        /// <summary>
        /// The default value for the overall request timeout.
        /// </summary>
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(100);

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> instance configured with the handlers provided.
        /// </summary>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> to authenticate requests.</param>
        /// <param name="domain">Domain of ServiceNow instance</param>
        /// <param name="version">The API version to use.</param>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <param name="finalHandler">The last HttpMessageHandler to HTTP calls. The default implementation creates a new instance of <see cref="HttpClientHandler"/> for each HttpClient.</param>
        /// <returns>An <see cref="HttpClient"/> instance with the configured handlers.</returns>
        public static HttpClient Create(
            IAuthenticationProvider authenticationProvider,
            string domain,
            string version = "",
            IWebProxy proxy = null,
            HttpMessageHandler finalHandler = null)
        {
            var handlers = CreateDefaultHandlers(authenticationProvider);
            return Create(handlers, domain, version, proxy, finalHandler);
        }

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> instance configured with the handlers provided.
        /// </summary>
        /// <param name="handlers">An ordered list of <see cref="DelegatingHandler"/> instances to be invoked as an
        ///     <see cref="HttpRequestMessage"/> travels from the <see cref="HttpClient"/> to the network and an
        ///     <see cref="HttpResponseMessage"/> travels from the network back to <see cref="HttpClient"/>.
        ///     The handlers are invoked in a top-down fashion. That is, the first entry is invoked first for
        ///     an outbound request message but last for an inbound response message.</param>
        /// <param name="domain"></param>
        /// <param name="version">The API version to use.</param>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <param name="finalHandler">The last HttpMessageHandler to HTTP calls.</param>
        /// <returns>An <see cref="HttpClient"/> instance with the configured handlers.</returns>
        public static HttpClient Create(
            IEnumerable<DelegatingHandler> handlers,
            string domain,
            string version = "",
            IWebProxy proxy = null,
            HttpMessageHandler finalHandler = null)
        {
            switch (finalHandler)
            {
                case null:
                    finalHandler = GetHttpHandler(proxy);
                    break;
                case HttpClientHandler httpClientHandler when httpClientHandler.Proxy == null && proxy != null:
                    httpClientHandler.Proxy = proxy;
                    break;
                case HttpClientHandler clientHandler when clientHandler.Proxy != null && proxy != null:
                    throw new ArgumentException(ErrorConstants.Messages.InvalidProxyArgument);
            }

            var (pipeline, featureFlags) = CreatePipelineWithFeatureFlags(handlers, finalHandler);
            var client = new HttpClient(pipeline);
            client.DefaultRequestHeaders.Add(SdkVersionHeaderName, SdkVersionHeaderValue);
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.SetFeatureFlag(featureFlags);
            client.Timeout = DefaultTimeout;
            client.BaseAddress = DetermineBaseAddress(domain, version);
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue {NoCache = true, NoStore = true};
            return client;
        }

        /// <summary>
        /// Create a default set of middleware for calling ServiceNow
        /// </summary>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> to authenticate requests.</param>
        public static IList<DelegatingHandler> CreateDefaultHandlers(IAuthenticationProvider authenticationProvider)
        {
            return new List<DelegatingHandler>
            {
                new AuthenticationHandler(authenticationProvider),
                new CompressionHandler(),
                new RetryHandler(),
                new RedirectHandler()
            };
        }

        /// <summary>
        /// Creates an instance of an <see cref="HttpMessageHandler"/> using the <see cref="DelegatingHandler"/> instances
        /// provided by <paramref name="handlers"/>. The resulting pipeline can be used to manually create <see cref="HttpClient"/>
        /// or <see cref="HttpMessageInvoker"/> instances with customized message handlers.
        /// </summary>
        /// <param name="handlers">An ordered list of <see cref="DelegatingHandler"/> instances to be invoked as part
        /// of sending an <see cref="HttpRequestMessage"/> and receiving an <see cref="HttpResponseMessage"/>.
        /// The handlers are invoked in a top-down fashion. That is, the first entry is invoked first for
        /// an outbound request message but last for an inbound response message.</param>
        /// <param name="finalHandler">The inner handler represents the destination of the HTTP message channel.</param>
        /// <returns>The HTTP message channel.</returns>
        public static HttpMessageHandler CreatePipeline(IEnumerable<DelegatingHandler> handlers,
            HttpMessageHandler finalHandler = null)
        {
            return CreatePipelineWithFeatureFlags(handlers, finalHandler).Pipeline;
        }

        /// <summary>
        /// Creates an instance of an <see cref="HttpMessageHandler"/> using the <see cref="DelegatingHandler"/> instances
        /// provided by <paramref name="handlers"/>. The resulting pipeline can be used to manually create <see cref="HttpClient"/>
        /// or <see cref="HttpMessageInvoker"/> instances with customized message handlers.
        /// </summary>
        /// <param name="handlers">An ordered list of <see cref="DelegatingHandler"/> instances to be invoked as part
        /// of sending an <see cref="HttpRequestMessage"/> and receiving an <see cref="HttpResponseMessage"/>.
        /// The handlers are invoked in a top-down fashion. That is, the first entry is invoked first for
        /// an outbound request message but last for an inbound response message.</param>
        /// <param name="finalHandler">The inner handler represents the destination of the HTTP message channel.</param>
        /// <returns>A tuple with The HTTP message channel and FeatureFlag for the handlers.</returns>
        internal static (HttpMessageHandler Pipeline, FeatureFlag FeatureFlags) CreatePipelineWithFeatureFlags(
            IEnumerable<DelegatingHandler> handlers, HttpMessageHandler finalHandler = null)
        {
            FeatureFlag handlerFlags = FeatureFlag.None;
            if (finalHandler == null)
            {
                finalHandler = GetHttpHandler();
            }

            if (handlers == null)
            {
                return (Pipeline: finalHandler, FeatureFlags: handlerFlags);
            }

            HttpMessageHandler httpPipeline = finalHandler;
            IEnumerable<DelegatingHandler> reversedHandlers = handlers.Reverse();
            HashSet<Type> existingHandlerTypes = new HashSet<Type>();
            foreach (DelegatingHandler handler in reversedHandlers)
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handlers), "DelegatingHandler array contains null item.");
                }

                // Check for duplicate handler by type.
                if (!existingHandlerTypes.Add(handler.GetType()))
                {
                    throw new ArgumentException(
                        $"DelegatingHandler array has a duplicate handler. {handler} has a duplicate handler.",
                        nameof(handlers));
                }

                // Existing InnerHandlers on handlers will be overwritten
                handler.InnerHandler = httpPipeline;
                httpPipeline = handler;

                // Register feature flag for the handler.
                handlerFlags |= GetHandlerFeatureFlag(handler);
            }

            return (Pipeline: httpPipeline, FeatureFlags: handlerFlags);
        }

        /// <summary>
        /// Gets the http handler.
        /// </summary>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <returns>
        /// HttpMessageHandler.
        /// </returns>
        internal static HttpMessageHandler GetHttpHandler(IWebProxy proxy = null)
        {
            return new HttpClientHandler
                {Proxy = proxy, AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.None};
        }

        /// <summary>
        /// Gets feature flag for the specified handler.
        /// </summary>
        /// <param name="delegatingHandler">The <see cref="DelegatingHandler"/> to get its feature flag.</param>
        /// <returns>Delegating handler feature flag.</returns>
        private static FeatureFlag GetHandlerFeatureFlag(DelegatingHandler delegatingHandler)
        {
            switch (delegatingHandler)
            {
                case AuthenticationHandler _:
                    return FeatureFlag.AuthHandler;
                case CompressionHandler _:
                    return FeatureFlag.CompressionHandler;
                case RetryHandler _:
                    return FeatureFlag.RetryHandler;
                case RedirectHandler _:
                    return FeatureFlag.RedirectHandler;
                default:
                    return FeatureFlag.None;
            }
        }

        private static Uri DetermineBaseAddress(string domain, string version)
        {
            var cloudAddress = string.Format(Constants.ApiUrlFormatString, domain, version);
            return new Uri(cloudAddress);
        }
    }
}
