// <copyright file="Tweet.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System;

    /// <summary>
    /// Represents tweet data
    /// </summary>
    public sealed class Tweet
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Tweet"/> class.
        /// </summary>
        /// <param name="id">Tweet ID</param>
        /// <param name="stamp">Tweet timestamp</param>
        /// <param name="text">Tweet text</param>
        public Tweet(string id, DateTime stamp, string text)
        {
            this.Id = id;
            this.Stamp = stamp;
            this.Text = text;
        }

        /// <summary>
        /// Gets tweet ID
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets tweet timestamp
        /// </summary>
        public DateTime Stamp { get; }

        /// <summary>
        /// Gets tweet text
        /// </summary>
        public string Text { get; }
    }
}
