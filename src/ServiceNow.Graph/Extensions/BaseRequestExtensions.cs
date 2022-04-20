using System;
using System.Net.Http;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Requests.Middleware.Options;

namespace ServiceNow.Graph.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="BaseRequest"/>
    /// </summary>
    public static class BaseRequestExtensions
    {
        /// <summary>
        /// Sets the default authentication provider to the default Authentication Middleware Handler for this request.
        /// This only works with the default authentication handler.
        /// If you use a custom authentication handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <returns></returns>
        internal static T WithDefaultAuthProvider<T>(this T baseRequest) where T : IBaseRequest
        {
            string authOptionKey = typeof(AuthenticationHandlerOption).ToString();
            if (baseRequest.MiddlewareOptions.ContainsKey(authOptionKey))
            {
                ((AuthenticationHandlerOption) baseRequest.MiddlewareOptions[authOptionKey]).AuthenticationProvider = baseRequest.Client.AuthenticationProvider;
            }
            else
            {
                baseRequest.MiddlewareOptions.Add(authOptionKey, new AuthenticationHandlerOption { AuthenticationProvider = baseRequest.Client.AuthenticationProvider });
            }
            return baseRequest;
        }

        /// <summary>
        /// Sets the PerRequestAuthProvider delegate handler to the default Authentication Middleware Handler to authenticate a single request.
        /// The PerRequestAuthProvider delegate handler must be set to the GraphServiceClient instance before using this extension method otherwise, it defaults to the default authentication provider.
        /// This only works with the default authentication handler.
        /// If you use a custom authentication handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <returns></returns>
        public static T WithPerRequestAuthProvider<T>(this T baseRequest) where T : IBaseRequest
        {
            if (baseRequest.Client.PerRequestAuthProvider != null)
            {
                string authOptionKey = typeof(AuthenticationHandlerOption).ToString();
                if (baseRequest.MiddlewareOptions.ContainsKey(authOptionKey))
                {
                    ((AuthenticationHandlerOption) baseRequest.MiddlewareOptions[authOptionKey]).AuthenticationProvider = baseRequest.Client.PerRequestAuthProvider();
                }
                else
                {
                    baseRequest.MiddlewareOptions.Add(authOptionKey, new AuthenticationHandlerOption { AuthenticationProvider = baseRequest.Client.PerRequestAuthProvider() });
                }
            }
            return baseRequest;
        }

        /// <summary>
        /// Sets a ShouldRetry delegate to the default Retry Middleware Handler for this request.
        /// This only works with the default Retry Middleware Handler.
        /// If you use a custom Retry Middleware Handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <param name="shouldRetry">A <see cref="Func{TResult}"/> for the request.</param>
        public static T WithShouldRetry<T>(this T baseRequest, Func<int, int, HttpResponseMessage, bool> shouldRetry) where T : IBaseRequest
        {
            string retryOptionKey = typeof(RetryHandlerOption).ToString();
            if (baseRequest.MiddlewareOptions.ContainsKey(retryOptionKey))
            {
                ((RetryHandlerOption) baseRequest.MiddlewareOptions[retryOptionKey]).ShouldRetry = shouldRetry;
            }
            else
            {
                baseRequest.MiddlewareOptions.Add(retryOptionKey, new RetryHandlerOption { ShouldRetry = shouldRetry });
            }
            return baseRequest;
        }

        /// <summary>
        /// Sets the maximum number of retries to the default Retry Middleware Handler for this request.
        /// This only works with the default Retry Middleware Handler.
        /// If you use a custom Retry Middleware Handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <param name="maxRetry">The maxRetry for the request.</param>
        public static T WithMaxRetry<T>(this T baseRequest, int maxRetry) where T : IBaseRequest
        {
            string retryOptionKey = typeof(RetryHandlerOption).ToString();
            if (baseRequest.MiddlewareOptions.ContainsKey(retryOptionKey))
            {
                ((RetryHandlerOption) baseRequest.MiddlewareOptions[retryOptionKey]).MaxRetry = maxRetry;
            }
            else
            {
                baseRequest.MiddlewareOptions.Add(retryOptionKey, new RetryHandlerOption { MaxRetry = maxRetry });
            }
            return baseRequest;
        }

        /// <summary>
        /// Sets the maximum time for request retries to the default Retry Middleware Handler for this request.
        /// This only works with the default Retry Middleware Handler.
        /// If you use a custom Retry Middleware Handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <param name="retriesTimeLimit">The retriestimelimit for the request in seconds.</param>
        public static T WithMaxRetry<T>(this T baseRequest, TimeSpan retriesTimeLimit) where T : IBaseRequest
        {
            string retryOptionKey = typeof(RetryHandlerOption).ToString();
            if (baseRequest.MiddlewareOptions.ContainsKey(retryOptionKey))
            {
                ((RetryHandlerOption) baseRequest.MiddlewareOptions[retryOptionKey]).RetriesTimeLimit = retriesTimeLimit;
            }
            else
            {
                baseRequest.MiddlewareOptions.Add(retryOptionKey, new RetryHandlerOption { RetriesTimeLimit = retriesTimeLimit });
            }
            return baseRequest;
        }

        /// <summary>
        /// Sets the maximum number of redirects to the default Redirect Middleware Handler for this request.
        /// This only works with the default Redirect Middleware Handler.
        /// If you use a custom Redirect Middleware Handler, you have to handle it's retrieval in your implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <param name="maxRedirects">Maximum number of redirects allowed for the request</param>
        public static T WithMaxRedirects<T>(this T baseRequest, int maxRedirects) where T : IBaseRequest
        {
            string redirectOptionKey = typeof(RedirectHandlerOption).ToString();
            if (baseRequest.MiddlewareOptions.ContainsKey(redirectOptionKey))
            {
                ((RedirectHandlerOption) baseRequest.MiddlewareOptions[redirectOptionKey]).MaxRedirect = maxRedirects;
            }
            else
            {
                baseRequest.MiddlewareOptions.Add(redirectOptionKey, new RedirectHandlerOption { MaxRedirect = maxRedirects });
            }
            return baseRequest;
        }

        /// <summary>
        /// Replaces the default response handler with a custom response handler for this request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest">The <see cref="BaseRequest"/> for the request.</param>
        /// <param name="responseHandler">The <see cref="IResponseHandler"/> for the request.</param>
        /// <exception cref="System.ArgumentNullException">If responseHandler is null.</exception>
        public static T WithResponseHandler<T>(this T baseRequest, IResponseHandler responseHandler) where T : BaseRequest
        {
            baseRequest.ResponseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));

            return baseRequest;
        }
    }
}
