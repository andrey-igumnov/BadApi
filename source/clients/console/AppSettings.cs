// <copyright file="AppSettings.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Client.Console
{
    using System;

    /// <summary>
    /// Represents application settings
    /// </summary>
    internal class AppSettings
    {
        /// <summary>
        /// Gets or sets Bad API SDK cinfiguration
        /// </summary>
        public BadApiSdkConfiguration BadApiSdkConfiguration { get; set; }

        /// <summary>
        /// Gets or sets request start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets request end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets output file path
        /// </summary>
        public string Output { get; set; }
    }
}
