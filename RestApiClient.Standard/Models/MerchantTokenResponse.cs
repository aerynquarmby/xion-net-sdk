// <copyright file="MerchantTokenResponse.cs" company="APIMatic">
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
    /// MerchantTokenResponse.
    /// </summary>
    public class MerchantTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantTokenResponse"/> class.
        /// </summary>
        public MerchantTokenResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantTokenResponse"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="token">token.</param>
        /// <param name="referralCode">referral_code.</param>
        /// <param name="message">message.</param>
        public MerchantTokenResponse(
            string type = null,
            string token = null,
            string referralCode = null,
            string message = null)
        {
            this.Type = type;
            this.Token = token;
            this.ReferralCode = referralCode;
            this.Message = message;
        }

        /// <summary>
        /// Type of the merchant token.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Token of the merchant.
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>
        /// Referral code of the merchant token.
        /// </summary>
        [JsonProperty("referral_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferralCode { get; set; }

        /// <summary>
        /// Message of the merchant token.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MerchantTokenResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is MerchantTokenResponse other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Token == null && other.Token == null) || (this.Token?.Equals(other.Token) == true)) &&
                ((this.ReferralCode == null && other.ReferralCode == null) || (this.ReferralCode?.Equals(other.ReferralCode) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.Token = {(this.Token == null ? "null" : this.Token)}");
            toStringOutput.Add($"this.ReferralCode = {(this.ReferralCode == null ? "null" : this.ReferralCode)}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");
        }
    }
}