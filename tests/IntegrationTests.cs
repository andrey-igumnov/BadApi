// <copyright file="IntegrationTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Represents intagration test
    /// </summary>
    [TestFixture]
    public sealed class IntegrationTests : TestBase
    {
        /// <summary>
        /// Tests get tweets
        /// </summary>
        [Test(Description = "Get tweets test")]
        public void GetTweetsTest()
        {
            var data = this.Sdk.GetTweets(new GetTweetsRequest
            {
                StartDate = new DateTime(2016, 01, 01),
                EndDate = new DateTime(2016, 02, 01),
            }).ToList();

            Assert.IsNotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
