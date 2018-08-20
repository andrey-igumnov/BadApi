// <copyright file="TestHelper.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk.Tests
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Represents helper class
    /// </summary>
    internal static class TestHelper
    {
        public static TestSdkConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new TestSdkConfiguration();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig.GetSection("testSdkConfiguration").Bind(configuration);

            return configuration;
        }

        /// <summary>
        /// Returns 
        /// </summary>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
