using Confluent.Kafka;
using Producer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Producer.Services
{
    public class KafkaProducerService
    {
        private readonly string _bootstrapServers;
        private readonly IProducer<Null, string> _producer;
        public KafkaProducerService(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task<DeliveryResult<Null, string>> SendAsync<T>(string topicName, T message)
        {
            string value = JsonSerializer.Serialize(message);
            var messageObject = new Message<Null, string>
            {
                Value = value
            };
            //using (_producer)
            //{
            var result = await _producer.ProduceAsync(topicName, messageObject);
            Console.WriteLine($"message  send to {topicName}");
            //Dispose();
            return result;
            //}
        }
        public void Dispose()
        {
            _producer.Flush();
            _producer.Dispose();
        }
        //public Task ensureTopicExistsAsync(string topicName)
        //{
        //    AdminClientConfig config = new AdminClientConfig
        //    {
        //        BootstrapServers = _bootstrapServers
        //    };
        //    var adminClient = new AdminClientBuilder(config).Build();

        //    var reult = adminClient.CreateTopicsAsync();
        //}
    }
}
