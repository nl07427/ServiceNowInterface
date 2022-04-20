using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Authentication
{
    /// <summary>
    /// An <see cref="IAuthenticationProvider"/> Acquire token by the adapted client credential flow used by ServiceNow.
    /// </summary>
    public class ClientCredentialProvider : IAuthenticationProvider
    {
        private readonly string _domain;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _userName;
        private readonly string _userPassword;
        internal static readonly HttpClient HttpClient = new HttpClient();
        internal readonly ResponseHandler ResponseHandler;

        /// <summary>
        /// Creates the ServiceNow hybrid client credential provider
        /// </summary>
        /// <param name="domain">domain, for example bel.service-now.com</param>
        /// <param name="clientId">Client id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="userName">user name</param>
        /// <param name="userPassword">password</param>
        public ClientCredentialProvider(string domain, string clientId, string clientSecret, string userName, string userPassword)
        {
            _domain = domain;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _userName = userName;
            _userPassword = userPassword;
            ResponseHandler = new ResponseHandler(new Serializer(new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            }));
        }

        /// <summary>
        /// Adds an authentication header to the incoming request.
        /// </summary>
        /// <param name="httpRequestMessage">A <see cref="HttpRequestMessage"/> to authenticate</param>
        public async System.Threading.Tasks.Task AuthenticateRequestAsync(HttpRequestMessage httpRequestMessage)
        {
            var url = string.Format(Constants.OAuthGetTokenFormatString, _domain);
            var formParameters = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"client_id", _clientId},
                {"client_secret", _clientSecret},
                {"username",  _userName},
                {"password", _userPassword }
            };
            using (var req = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(formParameters)
            })
            {
                try
                {
                    var response = await HttpClient.SendAsync(req).ConfigureAwait(false);
                    var authenticationResponse = await ResponseHandler.HandleResponse<AuthenticationResponse>(response).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(authenticationResponse?.AccessToken))
                    {
                        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(Constants.Headers.Bearer, authenticationResponse.AccessToken);
                    }
                    else
                    {
                        throw new AuthenticationException(new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.GeneralException,
                                DetailedMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            }
                        });
                    }
                }
                catch (Exception e)
                {
                    throw new AuthenticationException(new Error
                    {
                        ErrorDetail = new ErrorDetail
                        {
                            Message = ErrorConstants.Codes.GeneralException,
                            DetailedMessage = e.Message
                        }}, e);
                }
            }
        }
    }
}
