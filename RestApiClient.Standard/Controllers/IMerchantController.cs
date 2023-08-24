// <copyright file="IMerchantController.cs" company="APIMatic">
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
    /// IMerchantController.
    /// </summary>
    public interface IMerchantController
    {
        /// <summary>
        /// This endpoint is used to register master merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        Models.MerchantTokenResponse RegisterMasterMerchant(
                Models.RegisterMasterMerchantRequest body = null);

        /// <summary>
        /// This endpoint is used to register master merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        Task<Models.MerchantTokenResponse> RegisterMasterMerchantAsync(
                Models.RegisterMasterMerchantRequest body = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint is used to register sub merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        Models.MerchantTokenResponse RegisterSubMerchant(
                Models.RegisterSubMerchantRequest body = null);

        /// <summary>
        /// This endpoint is used to register sub merchant.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MerchantTokenResponse response from the API call.</returns>
        Task<Models.MerchantTokenResponse> RegisterSubMerchantAsync(
                Models.RegisterSubMerchantRequest body = null,
                CancellationToken cancellationToken = default);
    }
}