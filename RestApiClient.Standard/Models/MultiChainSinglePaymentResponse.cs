// <copyright file="MultiChainSinglePaymentResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// MultiChainSinglePaymentResponse.
    /// </summary>
    public class MultiChainSinglePaymentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiChainSinglePaymentResponse"/> class.
        /// </summary>
        public MultiChainSinglePaymentResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiChainSinglePaymentResponse"/> class.
        /// </summary>
        /// <param name="orderCode">orderCode.</param>
        /// <param name="hash">hash.</param>
        public MultiChainSinglePaymentResponse(
            string orderCode = null,
            string hash = null)
        {
            this.OrderCode = orderCode;
            this.Hash = hash;
        }

        /// <summary>
        /// Order code
        /// </summary>
        [JsonProperty("orderCode", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MultiChainSinglePaymentResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is MultiChainSinglePaymentResponse other &&                ((this.OrderCode == null && other.OrderCode == null) || (this.OrderCode?.Equals(other.OrderCode) == true)) &&
                ((this.Hash == null && other.Hash == null) || (this.Hash?.Equals(other.Hash) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderCode = {(this.OrderCode == null ? "null" : this.OrderCode)}");
            toStringOutput.Add($"this.Hash = {(this.Hash == null ? "null" : this.Hash)}");
        }
    }
}