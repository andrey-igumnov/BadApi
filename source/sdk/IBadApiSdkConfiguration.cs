// <copyright file="IBadApiSdkConfiguration.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System;

    /// <summary>
    /// Represrents interface for SDK configuration
    /// </summary>
    public interface IBadApiSdkConfiguration
    {
        /// <summary>
        /// Gets service URI
        /// </summary>
        Uri ServiceUri { get; }

        /// <summary>
        /// Gets request timeout
        /// </summary>
        TimeSpan? RequestTimeout { get; }
    }
}
