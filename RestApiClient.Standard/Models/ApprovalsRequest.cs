// <copyright file="ApprovalsRequest.cs" company="APIMatic">
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
    /// ApprovalsRequest.
    /// </summary>
    public class ApprovalsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalsRequest"/> class.
        /// </summary>
        public ApprovalsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalsRequest"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="sourceUserAddress">sourceUserAddress.</param>
        /// <param name="sourceChain">sourceChain.</param>
        /// <param name="sourceToken">sourceToken.</param>
        /// <param name="destinationUserAddress">destinationUserAddress.</param>
        /// <param name="destinationChain">destinationChain.</param>
        /// <param name="destinationToken">destinationToken.</param>
        /// <param name="amountUSD">amountUSD.</param>
        /// <param name="products">products.</param>
        public ApprovalsRequest(
            int? id = null,
            string sourceUserAddress = null,
            int? sourceChain = null,
            string sourceToken = null,
            string destinationUserAddress = null,
            int? destinationChain = 137,
            string destinationToken = null,
            double? amountUSD = null,
            List<double> products = null)
        {
            this.Id = id;
            this.SourceUserAddress = sourceUserAddress;
            this.SourceChain = sourceChain;
            this.SourceToken = sourceToken;
            this.DestinationUserAddress = destinationUserAddress;
            this.DestinationChain = destinationChain;
            this.DestinationToken = destinationToken;
            this.AmountUSD = amountUSD;
            this.Products = products;
        }

        /// <summary>
        /// ID of product.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        /// <summary>
        /// Wallet address of buyer.
        /// </summary>
        [JsonProperty("sourceUserAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUserAddress { get; set; }

        /// <summary>
        /// Chain ID for making the approvals.
        /// </summary>
        [JsonProperty("sourceChain", NullValueHandling = NullValueHandling.Ignore)]
        public int? SourceChain { get; set; }

        /// <summary>
        /// Token used for approvals.
        /// </summary>
        [JsonProperty("sourceToken", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceToken { get; set; }

        /// <summary>
        /// Wallet address of merchant.
        /// </summary>
        [JsonProperty("destinationUserAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationUserAddress { get; set; }

        /// <summary>
        /// Chain ID for polygon matic mainnet.
        /// </summary>
        [JsonProperty("destinationChain", NullValueHandling = NullValueHandling.Ignore)]
        public int? DestinationChain { get; set; }

        /// <summary>
        /// Token used for approvals.
        /// </summary>
        [JsonProperty("destinationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationToken { get; set; }

        /// <summary>
        /// Amount to be paid (USD).
        /// </summary>
        [JsonProperty("amountUSD", NullValueHandling = NullValueHandling.Ignore)]
        public double? AmountUSD { get; set; }

        /// <summary>
        /// List of product Ids.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Products { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ApprovalsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is ApprovalsRequest other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.SourceUserAddress == null && other.SourceUserAddress == null) || (this.SourceUserAddress?.Equals(other.SourceUserAddress) == true)) &&
                ((this.SourceChain == null && other.SourceChain == null) || (this.SourceChain?.Equals(other.SourceChain) == true)) &&
                ((this.SourceToken == null && other.SourceToken == null) || (this.SourceToken?.Equals(other.SourceToken) == true)) &&
                ((this.DestinationUserAddress == null && other.DestinationUserAddress == null) || (this.DestinationUserAddress?.Equals(other.DestinationUserAddress) == true)) &&
                ((this.DestinationChain == null && other.DestinationChain == null) || (this.DestinationChain?.Equals(other.DestinationChain) == true)) &&
                ((this.DestinationToken == null && other.DestinationToken == null) || (this.DestinationToken?.Equals(other.DestinationToken) == true)) &&
                ((this.AmountUSD == null && other.AmountUSD == null) || (this.AmountUSD?.Equals(other.AmountUSD) == true)) &&
                ((this.Products == null && other.Products == null) || (this.Products?.Equals(other.Products) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id.ToString())}");
            toStringOutput.Add($"this.SourceUserAddress = {(this.SourceUserAddress == null ? "null" : this.SourceUserAddress)}");
            toStringOutput.Add($"this.SourceChain = {(this.SourceChain == null ? "null" : this.SourceChain.ToString())}");
            toStringOutput.Add($"this.SourceToken = {(this.SourceToken == null ? "null" : this.SourceToken)}");
            toStringOutput.Add($"this.DestinationUserAddress = {(this.DestinationUserAddress == null ? "null" : this.DestinationUserAddress)}");
            toStringOutput.Add($"this.DestinationChain = {(this.DestinationChain == null ? "null" : this.DestinationChain.ToString())}");
            toStringOutput.Add($"this.DestinationToken = {(this.DestinationToken == null ? "null" : this.DestinationToken)}");
            toStringOutput.Add($"this.AmountUSD = {(this.AmountUSD == null ? "null" : this.AmountUSD.ToString())}");
            toStringOutput.Add($"this.Products = {(this.Products == null ? "null" : $"[{string.Join(", ", this.Products)} ]")}");
        }
    }
}