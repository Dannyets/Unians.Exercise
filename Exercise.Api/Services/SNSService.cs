using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Exercise.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Services
{
    public class SNSService : INotificationService
    {
        private IConfiguration _configuration;
        private AWSCredentials _credentials;
        private RegionEndpoint _region;

        public SNSService(IConfiguration configuration,
                          AWSCredentials credentials,
                          RegionEndpoint region)
        {
            _configuration = configuration;
            _credentials = credentials;
            _region = region;
        }

        public async Task PublishMessage<T>(T message)
        {
            using (var client = new AmazonSimpleNotificationServiceClient(_credentials, _region))
            {
                var topicArn = _configuration["TopicArn"];

                var messageJson = JsonConvert.SerializeObject(message);

                await client.PublishAsync(topicArn, messageJson);
            }
        }
    }
}
