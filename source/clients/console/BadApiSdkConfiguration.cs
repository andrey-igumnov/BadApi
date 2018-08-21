// <copyright file="BadApiSdkConfiguration.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Client.Console
{
    using System;
    using Sdk;

    /// <inheritdoc />
    internal sealed class BadApiSdkConfiguration : IBadApiSdkConfiguration
    {
        /// <inheritdoc />
        public Uri ServiceUri { get; set; }

        /// <inheritdoc />
        public TimeSpan? RequestTimeout { get; set; }
    }
}
