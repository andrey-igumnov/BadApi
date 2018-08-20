// <copyright file="UnitTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Represents SDK unit test
    /// </summary>
    [TestFixture]
    public class UnitTests : TestBase
    {
        /// <summary>
        /// Tests request parameters
        /// </summary>
        [Test(Description = "Tests incorrect request parameters")]
        public void IncorrectRequestParametersTest()
        {
            Assert.That(() => this.Sdk.GetTweets(new GetTweetsRequest
                {
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(-30),
                }).ToList(),
                Throws.Exception
                    .TypeOf<BadApiSdkException>()
                    .With.Property("Message")
                    .EqualTo("Request start date greather, than end date"));
        }

        /// <summary>
        /// Tests request parameters
        /// </summary>
        [Test(Description = "Tests <null> request parameter")]
        public void NullRequestParametersTest()
        {
            Assert.That(() => this.Sdk.GetTweets(null).ToList(),
                Throws.Exception
                    .TypeOf<BadApiSdkException>()
                    .With.Property("Message")
                    .EqualTo("Request is null"));
        }
    }
}
