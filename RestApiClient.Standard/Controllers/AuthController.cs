// <copyright file="AuthController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Authentication;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// AuthController.
    /// </summary>
    internal class AuthController : BaseController, IAuthController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        internal AuthController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This endpoint is used to register a new client access.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.RegisterTokenResponse response from the API call.</returns>
        public Models.RegisterTokenResponse Register(
                Models.RegisterTokenRequest body = null)
            => CoreHelper.RunTask(RegisterAsync(body));

        /// <summary>
        /// This endpoint is used to register a new client access.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RegisterTokenResponse response from the API call.</returns>
        public async Task<Models.RegisterTokenResponse> RegisterAsync(
                Models.RegisterTokenRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RegisterTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/register/token")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This endpoint is used to get a list of client Ids created by the merchant.
        /// </summary>
        /// <param name="merchantWalletAddress">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ListClientAppsResponse response from the API call.</returns>
        public Models.ListClientAppsResponse GetClientIds(
                string merchantWalletAddress)
            => CoreHelper.RunTask(GetClientIdsAsync(merchantWalletAddress));

        /// <summary>
        /// This endpoint is used to get a list of client Ids created by the merchant.
        /// </summary>
        /// <param name="merchantWalletAddress">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListClientAppsResponse response from the API call.</returns>
        public async Task<Models.ListClientAppsResponse> GetClientIdsAsync(
                string merchantWalletAddress,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListClientAppsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/clientapps/{merchantWalletAddress}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchantWalletAddress", merchantWalletAddress))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This endpoint is used to delete a registered client app.
        /// </summary>
        /// <param name="merchantWalletAddress">Required parameter: Example: .</param>
        /// <param name="clientId">Required parameter: Example: .</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string DeleteClientApp(
                string merchantWalletAddress,
                string clientId)
            => CoreHelper.RunTask(DeleteClientAppAsync(merchantWalletAddress, clientId));

        /// <summary>
        /// This endpoint is used to delete a registered client app.
        /// </summary>
        /// <param name="merchantWalletAddress">Required parameter: Example: .</param>
        /// <param name="clientId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> DeleteClientAppAsync(
                string merchantWalletAddress,
                string clientId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<string>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/clientapp/{merchantWalletAddress}/{clientId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchantWalletAddress", merchantWalletAddress))
                      .Template(_template => _template.Setup("clientId", clientId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);
    }
}