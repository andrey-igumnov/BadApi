// <copyright file="BadApiSdkConfiguration.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Client
{
    using System;
    using Sdk;

    internal sealed class BadApiSdkConfiguration : IBadApiSdkConfiguration
    {
        public Uri ServiceUri => new Uri("https://badapi.iqvia.io/api/v1/Tweets");

        public TimeSpan? RequestTimeout => null;
    }
}
