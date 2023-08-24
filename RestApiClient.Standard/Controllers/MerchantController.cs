// <copyright file="MerchantController.cs" company="APIMatic">
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
    /// MerchantController.
    /// </summary>
    internal class MerchantController : BaseController, IMerchantController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantController"/> class.
        /// </summary>
        internal MerchantController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This endpoint is used to register master merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        public Models.MerchantTokenResponse RegisterMasterMerchant(
                Models.RegisterMasterMerchantRequest body = null)
            => CoreHelper.RunTask(RegisterMasterMerchantAsync(body));

        /// <summary>
        /// This endpoint is used to register master merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        public async Task<Models.MerchantTokenResponse> RegisterMasterMerchantAsync(
                Models.RegisterMasterMerchantRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.MerchantTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/register/master-merchant")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This endpoint is used to register sub merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        public Models.MerchantTokenResponse RegisterSubMerchant(
                Models.RegisterSubMerchantRequest body = null)
            => CoreHelper.RunTask(RegisterSubMerchantAsync(body));

        /// <summary>
        /// This endpoint is used to register sub merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        public async Task<Models.MerchantTokenResponse> RegisterSubMerchantAsync(
                Models.RegisterSubMerchantRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.MerchantTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/register/sub-merchant")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);
    }
}