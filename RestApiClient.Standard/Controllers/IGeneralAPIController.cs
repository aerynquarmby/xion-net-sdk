// <copyright file="IGeneralAPIController.cs" company="APIMatic">
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
    /// IGeneralAPIController.
    /// </summary>
    public interface IGeneralAPIController
    {
        /// <summary>
        /// This endpoint is used to check the health of the API.
        /// </summary>
        /// <returns>Returns the string response from the API call.</returns>
        string Health();

        /// <summary>
        /// This endpoint is used to check the health of the API.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        Task<string> HealthAsync(CancellationToken cancellationToken = default);
    }
}