// <copyright file="RestApiClientClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using RestApiClient.Standard.Authentication;
    using RestApiClient.Standard.Controllers;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class RestApiClientClient : IRestApiClientClient
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://prodp-api.xion.app/api/v2" },
                    { Server.Websocket, "https://prodp-api.xion.app/ws" },
                }
            },
            {
                Environment.Sandbox, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://devp-api.xion.app/api/v2" },
                    { Server.Websocket, "https://devp-api.xion.app/ws" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "xionglobal-sdk v2.0.0 - DotNet";
        private readonly HttpCallBack httpCallBack;
        private readonly BearerAuthManager bearerAuthManager;
        private readonly Lazy<IGeneralAPIController> generalAPI;
        private readonly Lazy<IAuthController> auth;
        private readonly Lazy<ISingleBillPaymentsController> singleBillPayments;
        private readonly Lazy<IIframeController> iframe;
        private readonly Lazy<IMultiChainController> multiChain;
        private readonly Lazy<IMerchantController> merchant;

        private RestApiClientClient(
            Environment environment,
            string accessToken,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.HttpClientConfiguration = httpClientConfiguration;
            bearerAuthManager = new BearerAuthManager(accessToken);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                        {"global", bearerAuthManager}
                })
                .ApiCallback(httpCallBack)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();


            this.generalAPI = new Lazy<IGeneralAPIController>(
                () => new GeneralAPIController(globalConfiguration));
            this.auth = new Lazy<IAuthController>(
                () => new AuthController(globalConfiguration));
            this.singleBillPayments = new Lazy<ISingleBillPaymentsController>(
                () => new SingleBillPaymentsController(globalConfiguration));
            this.iframe = new Lazy<IIframeController>(
                () => new IframeController(globalConfiguration));
            this.multiChain = new Lazy<IMultiChainController>(
                () => new MultiChainController(globalConfiguration));
            this.merchant = new Lazy<IMerchantController>(
                () => new MerchantController(globalConfiguration));
        }

        /// <summary>
        /// Gets GeneralAPIController controller.
        /// </summary>
        public IGeneralAPIController GeneralAPIController => this.generalAPI.Value;

        /// <summary>
        /// Gets AuthController controller.
        /// </summary>
        public IAuthController AuthController => this.auth.Value;

        /// <summary>
        /// Gets SingleBillPaymentsController controller.
        /// </summary>
        public ISingleBillPaymentsController SingleBillPaymentsController => this.singleBillPayments.Value;

        /// <summary>
        /// Gets IframeController controller.
        /// </summary>
        public IIframeController IframeController => this.iframe.Value;

        /// <summary>
        /// Gets MultiChainController controller.
        /// </summary>
        public IMultiChainController MultiChainController => this.multiChain.Value;

        /// <summary>
        /// Gets MerchantController controller.
        /// </summary>
        public IMerchantController MerchantController => this.merchant.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with BearerAuth.
        /// </summary>
        private IBearerAuthCredentials BearerAuthCredentials => this.bearerAuthManager;

        /// <summary>
        /// Gets the access token to use with OAuth 2 authentication.
        /// </summary>
        public string AccessToken => this.BearerAuthCredentials.AccessToken;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the RestApiClientClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .AccessToken(BearerAuthCredentials.AccessToken)
                .HttpCallBack(httpCallBack)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> RestApiClientClient.</returns>
        internal static RestApiClientClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("REST_API_CLIENT_STANDARD_ENVIRONMENT");
            string accessToken = System.Environment.GetEnvironmentVariable("REST_API_CLIENT_STANDARD_ACCESS_TOKEN");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (accessToken != null)
            {
                builder.AccessToken(accessToken);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = RestApiClient.Standard.Environment.Production;
            private string accessToken = "";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for BearerAuth.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the RestApiClientClient using the values provided for the builder.
            /// </summary>
            /// <returns>RestApiClientClient.</returns>
            public RestApiClientClient Build()
            {

                return new RestApiClientClient(
                    environment,
                    accessToken,
                    httpCallBack,
                    httpClientConfig.Build());
            }
        }
    }
}
