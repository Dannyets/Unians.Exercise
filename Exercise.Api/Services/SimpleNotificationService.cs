using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using De.Amazon.Configuration.Models;
using Exercise.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Exercise.Api.Services
{
    public class SimpleNotificationService : INotificationService
    {
        private IConfiguration _configuration;
        private AWSCredentials _credentials;
        private RegionEndpoint _region;

        public SimpleNotificationService(IConfiguration configuration,
                                         AmazonConfiguration amazonConfiguration)
        {
            _configuration = configuration;
            _credentials = amazonConfiguration.Credentials;
            _region = amazonConfiguration.RegionEndpoint;
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
