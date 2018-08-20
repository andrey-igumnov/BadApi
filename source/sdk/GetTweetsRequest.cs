// <copyright file="GetTweetsRequest.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System;

    /// <summary>
    /// Represents request to get tweets
    /// </summary>
    public sealed class GetTweetsRequest
    {
        /// <summary>
        /// Gets or sets start date of the request
        /// </summary>
        public DateTime StartDate { internal get; set; }

        /// <summary>
        /// Gets or sets end date of the request
        /// </summary>
        public DateTime? EndDate { internal get; set; }
    }
}
