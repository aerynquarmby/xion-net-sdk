// <copyright file="RegisterMasterMerchantRequest.cs" company="APIMatic">
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
    /// RegisterMasterMerchantRequest.
    /// </summary>
    public class RegisterMasterMerchantRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMasterMerchantRequest"/> class.
        /// </summary>
        public RegisterMasterMerchantRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMasterMerchantRequest"/> class.
        /// </summary>
        /// <param name="companyName">company_name.</param>
        /// <param name="walletAddress">wallet_address.</param>
        public RegisterMasterMerchantRequest(
            string companyName = null,
            string walletAddress = null)
        {
            this.CompanyName = companyName;
            this.WalletAddress = walletAddress;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegisterMasterMerchantRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is RegisterMasterMerchantRequest other &&                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.WalletAddress == null && other.WalletAddress == null) || (this.WalletAddress?.Equals(other.WalletAddress) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.WalletAddress = {(this.WalletAddress == null ? "null" : this.WalletAddress)}");
        }
    }
}