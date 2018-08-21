// <copyright file="Program.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Client.Console
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Sdk;

    /// <summary>
    /// Represents programm class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments array</param>
        private static void Main(string[] args)
        {
            var appSettings = GetSettings();
            SaveResult(appSettings, FetchData(appSettings));
        }

        /// <summary>
        /// Returns data from Bad API
        /// </summary>
        /// <param name="appSettings">Applicateion settings</param>
        /// <returns>Tweets list</returns>
        private static List<Tweet> FetchData(AppSettings appSettings)
        {
            var serviceProvider = GetServiceProvider(appSettings);
            var sdk = serviceProvider.GetRequiredService<BadApiSdk>();

            var data = sdk.GetTweets(new GetTweetsRequest
            {
                StartDate = appSettings.StartDate.ToUniversalTime(),
                EndDate = appSettings.EndDate.ToUniversalTime(),
            }).ToList();

            return data;
        }

        /// <summary>
        /// Saves result to output
        /// </summary>
        /// <param name="appSettings">Applicateion settings</param>
        /// <param name="data">Result data</param>
        private static void SaveResult(AppSettings appSettings, List<Tweet> data)
        {
            if (File.Exists(appSettings.Output))
            {
                File.Delete(appSettings.Output);
            }

            File.WriteAllText(appSettings.Output, JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Returns service provider
        /// </summary>
        /// <param name="appSettings">Application settings</param>
        /// <returns>Service provider</returns>
        private static ServiceProvider GetServiceProvider(AppSettings appSettings)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IBadApiSdkConfiguration>(appSettings.BadApiSdkConfiguration);
            services.AddTransient<BadApiSdk>();
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        /// <summary>
        /// Returns application settings
        /// </summary>
        /// <returns>Application settings</returns>
        private static AppSettings GetSettings()
        {
            var appSettings = new AppSettings();

            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .Bind(appSettings);
            return appSettings;
        }
    }
}
