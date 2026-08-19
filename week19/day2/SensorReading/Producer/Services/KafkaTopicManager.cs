using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Services
{
    public class KafkaTopicManager
    {
        private readonly string _bootstrapServers;
        public KafkaTopicManager(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
        }
        public async Task EnsureTopicExistAsync(string topicName, int nunPartitions = 1, short replicationFacrore = 1)
        {
            AdminClientConfig config = new AdminClientConfig()
            {
                BootstrapServers = _bootstrapServers
            };
            using IAdminClient adminClient = new AdminClientBuilder(config).Build();
            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                    new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = nunPartitions,
                        ReplicationFactor = replicationFacrore
                    }
                });
                Console.WriteLine("Created successfuly");
            }
            catch (CreateTopicsException e)
            {
                if (e.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
                {
                    Console.WriteLine("already exists");
                }
                else
                {
                    throw new Exception($"Failed to create topic: {e.Results[0].Error.Reason}");
                }
            }
        }
    }
}
