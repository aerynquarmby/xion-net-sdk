// <copyright file="MultiChainSingleBillPaymentRequest.cs" company="APIMatic">
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
    /// MultiChainSingleBillPaymentRequest.
    /// </summary>
    public class MultiChainSingleBillPaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiChainSingleBillPaymentRequest"/> class.
        /// </summary>
        public MultiChainSingleBillPaymentRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiChainSingleBillPaymentRequest"/> class.
        /// </summary>
        /// <param name="productName">productName.</param>
        /// <param name="amountUSD">amountUSD.</param>
        /// <param name="token">token.</param>
        /// <param name="buyerAddress">buyerAddress.</param>
        /// <param name="chain">chain.</param>
        public MultiChainSingleBillPaymentRequest(
            string productName = null,
            double? amountUSD = null,
            string token = null,
            string buyerAddress = null,
            double? chain = null)
        {
            this.ProductName = productName;
            this.AmountUSD = amountUSD;
            this.Token = token;
            this.BuyerAddress = buyerAddress;
            this.Chain = chain;
        }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [JsonProperty("productName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName { get; set; }

        /// <summary>
        /// Amount to be paid (USD).
        /// </summary>
        [JsonProperty("amountUSD", NullValueHandling = NullValueHandling.Ignore)]
        public double? AmountUSD { get; set; }

        /// <summary>
        /// Token of the amount to paid.
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>
        /// Buyer's wallet address.
        /// </summary>
        [JsonProperty("buyerAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerAddress { get; set; }

        /// <summary>
        /// Chain to be used for payment.
        /// </summary>
        [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
        public double? Chain { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MultiChainSingleBillPaymentRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is MultiChainSingleBillPaymentRequest other &&                ((this.ProductName == null && other.ProductName == null) || (this.ProductName?.Equals(other.ProductName) == true)) &&
                ((this.AmountUSD == null && other.AmountUSD == null) || (this.AmountUSD?.Equals(other.AmountUSD) == true)) &&
                ((this.Token == null && other.Token == null) || (this.Token?.Equals(other.Token) == true)) &&
                ((this.BuyerAddress == null && other.BuyerAddress == null) || (this.BuyerAddress?.Equals(other.BuyerAddress) == true)) &&
                ((this.Chain == null && other.Chain == null) || (this.Chain?.Equals(other.Chain) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductName = {(this.ProductName == null ? "null" : this.ProductName)}");
            toStringOutput.Add($"this.AmountUSD = {(this.AmountUSD == null ? "null" : this.AmountUSD.ToString())}");
            toStringOutput.Add($"this.Token = {(this.Token == null ? "null" : this.Token)}");
            toStringOutput.Add($"this.BuyerAddress = {(this.BuyerAddress == null ? "null" : this.BuyerAddress)}");
            toStringOutput.Add($"this.Chain = {(this.Chain == null ? "null" : this.Chain.ToString())}");
        }
    }
}