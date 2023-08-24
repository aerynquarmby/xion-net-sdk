// <copyright file="RegisterMasterMerchantResponse.cs" company="APIMatic">
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
    /// RegisterMasterMerchantResponse.
    /// </summary>
    public class RegisterMasterMerchantResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMasterMerchantResponse"/> class.
        /// </summary>
        public RegisterMasterMerchantResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMasterMerchantResponse"/> class.
        /// </summary>
        /// <param name="companyName">company_name.</param>
        /// <param name="walletAddress">wallet_address.</param>
        /// <param name="createdAt">created_at.</param>
        public RegisterMasterMerchantResponse(
            string companyName = null,
            string walletAddress = null,
            DateTime? createdAt = null)
        {
            this.CompanyName = companyName;
            this.WalletAddress = walletAddress;
            this.CreatedAt = createdAt;
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
        /// Date and time master merchant was created.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegisterMasterMerchantResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RegisterMasterMerchantResponse other &&                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.WalletAddress == null && other.WalletAddress == null) || (this.WalletAddress?.Equals(other.WalletAddress) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.WalletAddress = {(this.WalletAddress == null ? "null" : this.WalletAddress)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
        }
    }
}