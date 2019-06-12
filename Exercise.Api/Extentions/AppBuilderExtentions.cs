using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Util;
using De.Amazon.Configuration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Extentions
{
    public static class AppBuilderExtentions
    {
        public async static Task RegisterToCloudMap(this IApplicationBuilder applicationBuilder, 
                                                    IConfiguration configuration,
                                                    AmazonConfiguration amazonConfiguration)
        {
            var instanceId = EC2InstanceMetadata.InstanceId;

            if (string.IsNullOrEmpty(instanceId))
            {
                throw new Exception("Failed to register to cloud map, EC2 Instance id is null or empty");
            }

            var ipv4 = EC2InstanceMetadata.PrivateIpAddress;

            var serviceId = configuration["CloudMap:ServiceId"];

            var client = new AmazonServiceDiscoveryClient(amazonConfiguration.Credentials, amazonConfiguration.RegionEndpoint);

            var registerInstanceReuqest = new RegisterInstanceRequest
            {
                InstanceId = instanceId,
                ServiceId = serviceId,
                Attributes = new Dictionary<string, string>
                {
                    { "AWS_INSTANCE_IPV4", ipv4 },
                    { "AWS_INSTANCE_PORT", "80" }
                }
            };

            await client.RegisterInstanceAsync(registerInstanceReuqest);
        }
    }
}
