using System;

namespace BadApi.Client
{
    using System.Linq;
    using Sdk;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sdk = new BadApiSdk(new BadApiSdkConfiguration());
            var data = sdk.GetTweets(new GetTweetsRequest
            {
                StartDate = new DateTime(2016, 01, 01),
                EndDate = new DateTime(2018, 01, 01).AddTicks(-1),
            }).FirstOrDefault(t => t.Id == "976934364733784065");


        }
    }
}
