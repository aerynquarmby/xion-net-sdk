// <copyright file="IRestApiClientClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard
{
    using System;
    using RestApiClient.Standard.Controllers;

    /// <summary>
    /// IRestApiClientClient.
    /// </summary>
    public interface IRestApiClientClient : IConfiguration
    {
        /// <summary>
        /// Gets instance for IGeneralAPIController.
        /// </summary>
        IGeneralAPIController GeneralAPIController { get; }

        /// <summary>
        /// Gets instance for IAuthController.
        /// </summary>
        IAuthController AuthController { get; }

        /// <summary>
        /// Gets instance for ISingleBillPaymentsController.
        /// </summary>
        ISingleBillPaymentsController SingleBillPaymentsController { get; }

        /// <summary>
        /// Gets instance for IIframeController.
        /// </summary>
        IIframeController IframeController { get; }

        /// <summary>
        /// Gets instance for IMultiChainController.
        /// </summary>
        IMultiChainController MultiChainController { get; }

        /// <summary>
        /// Gets instance for IMerchantController.
        /// </summary>
        IMerchantController MerchantController { get; }
    }
}