// <copyright file="RegisterSubMerchantRequest.cs" company="APIMatic">
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
    /// RegisterSubMerchantRequest.
    /// </summary>
    public class RegisterSubMerchantRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterSubMerchantRequest"/> class.
        /// </summary>
        public RegisterSubMerchantRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterSubMerchantRequest"/> class.
        /// </summary>
        /// <param name="companyName">company_name.</param>
        /// <param name="walletAddress">wallet_address.</param>
        /// <param name="chargedFees">charged_fees.</param>
        public RegisterSubMerchantRequest(
            string companyName = null,
            string walletAddress = null,
            double? chargedFees = null)
        {
            this.CompanyName = companyName;
            this.WalletAddress = walletAddress;
            this.ChargedFees = chargedFees;
        }

        /// <summary>
        /// Name of the company.
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Wallet address of the company.
        /// </summary>
        [JsonProperty("wallet_address", NullValueHandling = NullValueHandling.Ignore)]
        public string WalletAddress { get; set; }

        /// <summary>
        /// Charged fees of the company.
        /// </summary>
        [JsonProperty("charged_fees", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChargedFees { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegisterSubMerchantRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is RegisterSubMerchantRequest other &&                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.WalletAddress == null && other.WalletAddress == null) || (this.WalletAddress?.Equals(other.WalletAddress) == true)) &&
                ((this.ChargedFees == null && other.ChargedFees == null) || (this.ChargedFees?.Equals(other.ChargedFees) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.WalletAddress = {(this.WalletAddress == null ? "null" : this.WalletAddress)}");
            toStringOutput.Add($"this.ChargedFees = {(this.ChargedFees == null ? "null" : this.ChargedFees.ToString())}");
        }
    }
}