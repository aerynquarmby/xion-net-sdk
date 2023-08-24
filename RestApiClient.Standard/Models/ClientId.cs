// <copyright file="ClientId.cs" company="APIMatic">
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
    /// ClientId.
    /// </summary>
    public class ClientId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientId"/> class.
        /// </summary>
        public ClientId()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientId"/> class.
        /// </summary>
        /// <param name="clientIdProp">clientId.</param>
        /// <param name="name">name.</param>
        /// <param name="createdAt">createdAt.</param>
        public ClientId(
            string clientIdProp = null,
            string name = null,
            DateTime? createdAt = null)
        {
            this.ClientIdProp = clientIdProp;
            this.Name = name;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Client Id of the client app.
        /// </summary>
        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientIdProp { get; set; }

        /// <summary>
        /// Name of the client app.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Date and time client Id was created.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ClientId : ({string.Join(", ", toStringOutput)})";
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
            return obj is ClientId other &&                ((this.ClientIdProp == null && other.ClientIdProp == null) || (this.ClientIdProp?.Equals(other.ClientIdProp) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientIdProp = {(this.ClientIdProp == null ? "null" : this.ClientIdProp)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
        }
    }
}