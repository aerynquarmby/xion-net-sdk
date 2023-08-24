// <copyright file="IMultiChainController.cs" company="APIMatic">
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
    /// IMultiChainController.
    /// </summary>
    public interface IMultiChainController
    {
        /// <summary>
        /// This endpoint is used to make a multi chain single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MultiChainSinglePaymentResponse response from the API call.</returns>
        Models.MultiChainSinglePaymentResponse MultiChainSingleBillPayment(
                Models.MultiChainSingleBillPaymentRequest body = null);

        /// <summary>
        /// This endpoint is used to make a multi chain single bill payment.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MultiChainSinglePaymentResponse response from the API call.</returns>
        Task<Models.MultiChainSinglePaymentResponse> MultiChainSingleBillPaymentAsync(
                Models.MultiChainSingleBillPaymentRequest body = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint is used to post approvals.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        void PostApprovals(
                Models.ApprovalsRequest body = null);

        /// <summary>
        /// This endpoint is used to post approvals.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        Task PostApprovalsAsync(
                Models.ApprovalsRequest body = null,
                CancellationToken cancellationToken = default);
    }
}