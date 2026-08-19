using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducer.Services
{
    public class KafkaTopicManager
    {
        private readonly string _bootstrapServers;
        public KafkaTopicManager(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
        }
        public async Task EnsureTopicExistsAsync(string topicName, int numPartitions = 1, short replictaionFactor = 1)
        {
            var config = new AdminClientConfig()
            {
                BootstrapServers = _bootstrapServers
            };
            using var adminClient = new AdminClientBuilder(config).Build();
            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                    new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = numPartitions,
                        ReplicationFactor = replictaionFactor
                    }
                });
                Console.WriteLine($"topic {topicName} created succesfully");
            }
            catch (CreateTopicsException ex)
            {
                if (ex.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
                {
                    Console.WriteLine("already exist");
                }
                else
                {
                    throw new Exception($"Failed to create topic: {ex.Results[0].Error.Reason}");
                }
            }
        }
    }
}
