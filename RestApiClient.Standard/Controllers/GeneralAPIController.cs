// <copyright file="GeneralAPIController.cs" company="APIMatic">
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
    /// GeneralAPIController.
    /// </summary>
    internal class GeneralAPIController : BaseController, IGeneralAPIController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralAPIController"/> class.
        /// </summary>
        internal GeneralAPIController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This endpoint is used to check the health of the API.
        /// </summary>
        /// <returns>Returns the string response from the API call.</returns>
        public string Health()
            => CoreHelper.RunTask(HealthAsync());

        /// <summary>
        /// This endpoint is used to check the health of the API.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> HealthAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<string>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/health")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken);
    }
}