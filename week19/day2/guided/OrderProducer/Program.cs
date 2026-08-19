using OrderProducer.Models;
using OrderProducer.Services;

const string bootstrapServers = "localhost:9092";
const string topicName = "orders";
Console.WriteLine("=== Order Producer ===\n");

var topicManager = new KafkaTopicManager(bootstrapServers);
await topicManager.EnsureTopicExistsAsync(topicName);

Console.WriteLine();