// <copyright file="TestSdkConfiguration.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk.Tests
{
    using System;

    /// <summary>
    /// Represents SDK configuration for test project
    /// </summary>
    public sealed class TestSdkConfiguration : IBadApiSdkConfiguration
    {
        /// <inheritdoc />
        public Uri ServiceUri { get; set; }

        /// <inheritdoc />
        public TimeSpan? RequestTimeout { get; set; }
    }
}
