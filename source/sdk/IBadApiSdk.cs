// <copyright file="IBadApiSdk.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents Bad API SDK interface
    /// </summary>
    public interface IBadApiSdk
    {
        /// <summary>
        /// Returns tweet from bad API by request
        /// </summary>
        /// <param name="request">Get tweets request</param>
        /// <returns>Collection of tweets</returns>
        IEnumerable<Tweet> GetTweets(GetTweetsRequest request);
    }
}
