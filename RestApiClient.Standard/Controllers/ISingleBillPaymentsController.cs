// <copyright file="ISingleBillPaymentsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Request;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// ISingleBillPaymentsController.
    /// </summary>
    public interface ISingleBillPaymentsController
    {
        /// <summary>
        /// This endpoint is used to make a single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.SingleBillPaymentResponse response from the API call.</returns>
        Models.SingleBillPaymentResponse SingleBillPayment(
                Models.SingleBillPaymentRequest body = null);

        /// <summary>
        /// This endpoint is used to make a single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SingleBillPaymentResponse response from the API call.</returns>
        Task<Models.SingleBillPaymentResponse> SingleBillPaymentAsync(
                Models.SingleBillPaymentRequest body = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint is used to get the status of an order.
        /// </summary>
        /// <param name="orderCode">Required parameter: Example: .</param>
        /// <returns>Returns the string response from the API call.</returns>
        string GetOrderStatus(
                string orderCode);

        /// <summary>
        /// This endpoint is used to get the status of an order.
        /// </summary>
        /// <param name="orderCode">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        Task<string> GetOrderStatusAsync(
                string orderCode,
                CancellationToken cancellationToken = default);
    }
}