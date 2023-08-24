// <copyright file="MultiChainController.cs" company="APIMatic">
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
    /// MultiChainController.
    /// </summary>
    internal class MultiChainController : BaseController, IMultiChainController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiChainController"/> class.
        /// </summary>
        internal MultiChainController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This endpoint is used to make a multi chain single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MultiChainSinglePaymentResponse response from the API call.</returns>
        public Models.MultiChainSinglePaymentResponse MultiChainSingleBillPayment(
                Models.MultiChainSingleBillPaymentRequest body = null)
            => CoreHelper.RunTask(MultiChainSingleBillPaymentAsync(body));

        /// <summary>
        /// This endpoint is used to make a multi chain single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MultiChainSinglePaymentResponse response from the API call.</returns>
        public async Task<Models.MultiChainSinglePaymentResponse> MultiChainSingleBillPaymentAsync(
                Models.MultiChainSingleBillPaymentRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.MultiChainSinglePaymentResponse>()
              .Server(Server.Websocket)
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/multi-chain/single/payment")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This endpoint is used to post approvals.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        public void PostApprovals(
                Models.ApprovalsRequest body = null)
            => CoreHelper.RunVoidTask(PostApprovalsAsync(body));

        /// <summary>
        /// This endpoint is used to post approvals.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task PostApprovalsAsync(
                Models.ApprovalsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .Server(Server.Websocket)
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/approvals")
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