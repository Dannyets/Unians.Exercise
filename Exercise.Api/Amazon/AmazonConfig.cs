using Amazon;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Amazon
{
    public class AmazonConfig
    {
        public AmazonConfig(AWSCredentials credentials,
                            RegionEndpoint regionEndpoint)
        {
            Credentials = credentials;
            RegionEndpoint = regionEndpoint;
        }

        public AWSCredentials Credentials { get; }

        public RegionEndpoint RegionEndpoint { get; }
    }
}
