// <copyright file="MerchantControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Controllers;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// MerchantControllerTest.
    /// </summary>
    [TestFixture]
    public class MerchantControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IMerchantController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.MerchantController;
        }

        /// <summary>
        /// This endpoint is used to register master merchant.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRegisterMasterMerchant()
        {
            // Parameters for the API call
            Standard.Models.RegisterMasterMerchantRequest body = null;

            // Perform API call
            Standard.Models.MerchantTokenResponse result = null;
            try
            {
                result = await this.controller.RegisterMasterMerchantAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// This endpoint is used to register sub merchant.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRegisterSubMerchant()
        {
            // Parameters for the API call
            Standard.Models.RegisterSubMerchantRequest body = null;

            // Perform API call
            Standard.Models.MerchantTokenResponse result = null;
            try
            {
                result = await this.controller.RegisterSubMerchantAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }
    }
}