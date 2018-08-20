// <copyright file="BadApiSdk.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace BadApi.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;

    /// <inheritdoc />
    public sealed class BadApiSdk : IBadApiSdk
    {
        /// <summary>
        /// SDK configuration
        /// </summary>
        private readonly IBadApiSdkConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of <see cref="BadApiSdk"/> class.
        /// </summary>
        /// <param name="configuration">Bad API SDK configuration</param>
        public BadApiSdk(IBadApiSdkConfiguration configuration)
        {
            if (configuration?.ServiceUri == null)
            {
                throw new BadApiSdkException(
                    "Configuration or service URI is null",
                    new ArgumentNullException(nameof(configuration)));
            }

            this.configuration = configuration;
        }


        /// <inheritdoc />
        public IEnumerable<Tweet> GetTweets(GetTweetsRequest request)
        {
            if (request == null)
            {
                throw new BadApiSdkException("Request is null", new ArgumentNullException(nameof(request)));
            }

            if (request.StartDate > request.EndDate)
            {
                throw new BadApiSdkException("Request start date greather, than end date");
            }

            var endDate = request.EndDate ?? DateTime.UtcNow;
            var startTime = request.StartDate;
            int tweetsCount;
            var uniqueCheck = new Dictionary<string, Tweet>();

            do
            {
                var tweets = this.GetTweetsFromApiAsync(startTime, endDate).Result;

                if (tweets.Count == 0)
                {
                    break;
                }

                tweetsCount = tweets.Count;

                foreach (var tweet in tweets)
                {
                    if (!uniqueCheck.ContainsKey(tweet.Id))
                    {
                        uniqueCheck.Add(tweet.Id, tweet);

                        yield return tweet;
                    }
                }

                startTime = tweets.Max(t => t.Stamp.AddTicks(1));

            } while (tweetsCount >= 100);
        }

        /// <summary>
        /// Retuns tweets from API
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns></returns>
        private async Task<ICollection<Tweet>> GetTweetsFromApiAsync(DateTime startDate, DateTime endDate)
        {
            using (var client = new HttpClient())
            {
                if (this.configuration.RequestTimeout.HasValue)
                {
                    client.Timeout = this.configuration.RequestTimeout.Value;
                }

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var query = HttpUtility.ParseQueryString(string.Empty);
                query["startDate"] = startDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                query["endDate"] = endDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");

                var builder = new UriBuilder(this.configuration.ServiceUri)
                {
                    Query = query.ToString()
                };

                try
                {
                    var requestResult = await client.GetAsync(builder.Uri);
                    var contentString = await requestResult.Content.ReadAsStringAsync();

                    switch (requestResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            return JsonConvert.DeserializeObject<List<Tweet>>(contentString);
                        case HttpStatusCode.BadRequest:
                            throw new BadApiSdkException("Bad request: invalid startDate and/or endDate.");
                        case HttpStatusCode.InternalServerError:
                            throw new BadApiSdkException("Internal server error.");
                        default:
                            throw new BadApiSdkException($"Unxepected status code: {requestResult.StatusCode}. Content {contentString}");
                    }
                }
                catch (Exception e)
                {
                    throw new BadApiSdkException(e.Message, e);
                }
            }
        }
    }
}
