// <copyright file="Options.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Client.Console
{
    using System;
    using CommandLine;

    /// <summary>
    /// Represents command line options
    /// </summary>
    internal class Options
    {
        /// <summary>
        /// Gets or sets output result file path
        /// </summary>
        [Option('o', "output", Required = false, HelpText = "Output result file path.")]
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets start date
        /// </summary>
        [Option('s', "start", Required = false, HelpText = "Start date.")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets end date
        /// </summary>
        [Option('e', "end", Required = false, HelpText = "End date.")]
        public DateTime? EndDate { get; set; }
    }
}
