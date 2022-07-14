using System;
using System.Net.Http;
using Newtonsoft.Json;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// A default <see cref="IBaseClient"/> implementation.
    /// </summary>
    public class BaseClient : IBaseClient
    {
        private string _url;

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="url">The domain. For example, customer.service-now.com"</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        /// <param name="version"></param>
        protected BaseClient(string url,
            IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null, string version = "")
        {
            Url = url;
            Version = version;
            AuthenticationProvider = authenticationProvider;
            HttpProvider = httpProvider ?? new HttpProvider(url, version, new Serializer(new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            }));
        }

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="url">The domain of the ServiceNow instance. For example, customer.service-now.com</param>
        /// <param name="version">The version of the ServiceNow API, for example "now" for the latest endpoint</param>
        /// <param name="httpClient">The custom <see cref="HttpClient"/> to be used for making requests</param>
        public BaseClient(
            string url,
            string version,
            HttpClient httpClient)
        {
            Url = url;
            Version = version;
            HttpProvider = new SimpleHttpProvider(httpClient, url, version);
        }

        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating requests.
        /// </summary>
        public IAuthenticationProvider AuthenticationProvider { get; set; }

        /// <summary>
        /// Gets or sets the base URL for requests of the client.
        /// </summary>
        public string Url
        {
            get => _url;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.InvalidRequest,
                                DetailedMessage = ErrorConstants.Messages.DomainMissing
                            }
                        });
                }

                _url = value.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets the version of the ServiceNow api.
        /// </summary>
        public string Version
        {
            get;
            private set;
            //    if (string.IsNullOrEmpty(value))
            //{
            //    throw new ServiceException(
            //        new Error
            //        {
            //            ErrorDetail = new ErrorDetail
            //            {
            //                Message = ErrorConstants.Codes.InvalidRequest,
            //                DetailedMessage = ErrorConstants.Messages.VersionMissing
            //            }
            //        });
            //}
        }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; }

        /// <summary>
        /// Gets or Sets the <see cref="IAuthenticationProvider"/> for authenticating a single HTTP requests. 
        /// </summary>
        public Func<IAuthenticationProvider> PerRequestAuthProvider { get; set; }
    }
}
