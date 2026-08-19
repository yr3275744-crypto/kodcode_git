using Confluent.Kafka;
using SensorApi.Models;
using System.Text.Json;

namespace SensorApi.Services
{
    public class KafkaConsumerService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly string _topicName;

        public KafkaConsumerService(IConfiguration configuration)
        {
            string bootstrapServers = configuration["kafka:bootstrapServers"] ?? "kafka:9092";
            string groupId = configuration["Kafka:GroupId"] ?? "sensor-api-group";
            _topicName = configuration["Kafka:TopicName"] ?? "sensor-readings";

            var config = new ConsumerConfig()
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(_topicName);
            Console.WriteLine($"Kafka Consumer subscribed to topic '{_topicName}' with GroupId '{groupId}'");
        }
        public SensorReading? ConsumeNextSensor(TimeSpan timeout)
        {
            try
            {
                var consumeResult = _consumer.Consume(timeout);

                if (consumeResult == null || consumeResult.IsPartitionEOF)
                {
                    return null;
                }
                SensorReading? sensor = JsonSerializer.Deserialize<SensorReading>(consumeResult.Message.Value);
                return sensor;
            }
            catch (ConsumeException ex)
            {
                Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
                return null;
            }
        }
    }
}
