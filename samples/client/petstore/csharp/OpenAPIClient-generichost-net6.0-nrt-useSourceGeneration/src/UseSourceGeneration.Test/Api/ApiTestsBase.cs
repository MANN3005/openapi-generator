/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Extensions.Hosting;
using UseSourceGeneration.Client;
using UseSourceGeneration.Extensions;


/* *********************************************************************************
*              Follow these manual steps to construct tests.
*              This file will not be overwritten.
*  *********************************************************************************
* 1. Navigate to ApiTests.Base.cs and ensure any tokens are being created correctly.
*    Take care not to commit credentials to any repository.
*
* 2. Mocking is coordinated by ApiTestsBase#AddApiHttpClients.
*    To mock the client, use the generic AddApiHttpClients.
*    To mock the server, change the client's BaseAddress.
*
* 3. Locate the test you want below
*      - remove the skip property from the Fact attribute
*      - set the value of any variables if necessary
*
* 4. Run the tests and ensure they work.
*
*/


namespace UseSourceGeneration.Test.Api
{
    /// <summary>
    ///  Base class for API tests
    /// </summary>
    public class ApiTestsBase
    {
        protected readonly IHost _host;

        public ApiTestsBase(string[] args)
        {
            _host = CreateHostBuilder(args).Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureApi((context, services, options) =>
            {
                string apiKeyTokenValue1 = context.Configuration["<token>"] ?? throw new Exception("Token not found.");
                ApiKeyToken apiKeyToken1 = new(apiKeyTokenValue1, "api_key", timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(apiKeyToken1);

                string apiKeyTokenValue2 = context.Configuration["<token>"] ?? throw new Exception("Token not found.");
                ApiKeyToken apiKeyToken2 = new(apiKeyTokenValue2, "api_key_query", timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(apiKeyToken2);

                string bearerTokenValue1 = context.Configuration["<token>"] ?? throw new Exception("Token not found.");
                BearerToken bearerToken1 = new(bearerTokenValue1, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(bearerToken1);

                string basicTokenUsername1 = context.Configuration["<username>"] ?? throw new Exception("Username not found.");
                string basicTokenPassword1 = context.Configuration["<password>"] ?? throw new Exception("Password not found.");
                BasicToken basicToken1 = new(basicTokenUsername1, basicTokenPassword1, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(basicToken1);

                HttpSigningConfiguration config1 = new("<keyId>", "<keyFilePath>", null, new List<string>(), HashAlgorithmName.SHA256, "<signingAlgorithm>", 0);
                HttpSignatureToken httpSignatureToken1 = new(config1, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(httpSignatureToken1);

                string oauthTokenValue1 = context.Configuration["<token>"] ?? throw new Exception("Token not found.");
                OAuthToken oauthToken1 = new(oauthTokenValue1, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(oauthToken1);
            });
    }
}
