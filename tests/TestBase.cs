// <copyright file="IntegrationTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;

    /// <summary>
    /// Base test class
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// SDK configuration
        /// </summary>
        protected TestSdkConfiguration Configuration;

        /// <summary>
        /// Bad API sdk
        /// </summary>
        protected IBadApiSdk Sdk;

        /// <summary>
        /// Initializes test context
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.Configuration = TestHelper.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
            var services = new ServiceCollection();
            services.AddSingleton<IBadApiSdkConfiguration>(this.Configuration);
            services.AddTransient<BadApiSdk>();
            var serviceProvider = services.BuildServiceProvider();
            this.Sdk = serviceProvider.GetRequiredService<BadApiSdk>();
        }
    }
}
