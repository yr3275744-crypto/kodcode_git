using Producer.Models;
using Producer.Services;

const string bootstrapServers = "kafka:9092";
const string topicName = "sensor-readings";

KafkaTopicManager kafkaTopicManager = new KafkaTopicManager(bootstrapServers);

await kafkaTopicManager.EnsureTopicExistAsync(topicName);
Console.WriteLine();

var sensors = new List<SensorReading>
{
    new SensorReading
    {
        SensorId = 1,
        Temperature = 55,
        Timestamp = DateTime.Now
    },
    new SensorReading
    {
        SensorId = 2,
        Temperature = 52,
        Timestamp = DateTime.Today
    }
};
SensorProducerService sensorProducerService = new SensorProducerService(bootstrapServers, topicName);

foreach (SensorReading sensor in sensors)
{
    var result = await sensorProducerService.SendSensorAsync(sensor);
}

sensorProducerService.Dispose();

