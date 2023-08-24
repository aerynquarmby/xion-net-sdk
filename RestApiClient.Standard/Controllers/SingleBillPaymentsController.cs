// <copyright file="SingleBillPaymentsController.cs" company="APIMatic">
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
    /// SingleBillPaymentsController.
    /// </summary>
    internal class SingleBillPaymentsController : BaseController, ISingleBillPaymentsController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleBillPaymentsController"/> class.
        /// </summary>
        internal SingleBillPaymentsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This endpoint is used to make a single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.SingleBillPaymentResponse response from the API call.</returns>
        public Models.SingleBillPaymentResponse SingleBillPayment(
                Models.SingleBillPaymentRequest body = null)
            => CoreHelper.RunTask(SingleBillPaymentAsync(body));

        /// <summary>
        /// This endpoint is used to make a single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SingleBillPaymentResponse response from the API call.</returns>
        public async Task<Models.SingleBillPaymentResponse> SingleBillPaymentAsync(
                Models.SingleBillPaymentRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SingleBillPaymentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/single/payment")
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
        /// This endpoint is used to get the status of an order.
        /// </summary>
        /// <param name="orderCode">Required parameter: Example: .</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string GetOrderStatus(
                string orderCode)
            => CoreHelper.RunTask(GetOrderStatusAsync(orderCode));

        /// <summary>
        /// This endpoint is used to get the status of an order.
        /// </summary>
        /// <param name="orderCode">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> GetOrderStatusAsync(
                string orderCode,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<string>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/order/status/{orderCode}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("orderCode", orderCode))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ErrorResponseException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken);
    }
}