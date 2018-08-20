// <copyright file="BadApiSdkException.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents specific Bad API SDK exception
    /// </summary>
    [Serializable]
    public class BadApiSdkException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadApiSdkException"/> class
        /// </summary>
        public BadApiSdkException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadApiSdkException"/> class
        /// </summary>
        /// <param name="message">Exception message</param>
        public BadApiSdkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadApiSdkException"/> class
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public BadApiSdkException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadApiSdkException"/> class
        /// </summary>
        /// <param name="serializationInfo">Serialization Info</param>
        /// <param name="streamingContext">Streaming Context</param>
        protected BadApiSdkException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
