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
    public class SensorProducerService
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topicName;

        public SensorProducerService(string bootstrapServers, string topicName)
        {
            Config? config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = "order-producer"
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
            _topicName = topicName;

        }
        public async Task<DeliveryResult<string, string>> SendSensorAsync(SensorReading sensorReading)
        {
            var key = sensorReading.SensorId.ToString();
            var value = JsonSerializer.Serialize(sensorReading);

            var message = new Message<string, string>()
            {
                Key = key,
                Value = value
            };
            DeliveryResult<string, string> result = await _producer.ProduceAsync(_topicName, message);
            Console.WriteLine($"Sent order {sensorReading.SensorId}");
            return result;
        }
        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }
    }
}
