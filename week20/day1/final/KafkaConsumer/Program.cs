using Confluent.Kafka;

string bootstrapServers = "kafka:9092";
var consumerConfig = new ConsumerConfig
{
    BootstrapServers = bootstrapServers,
    GroupId = "ggg",
    AutoOffsetReset = AutoOffsetReset.Earliest
};
var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
while (true)
{
    consumer.Subscribe("try-topic");
    var result = consumer.Consume(TimeSpan.FromSeconds(5));
    if (result == null || result.Message!.Value == null)
    {
        Console.WriteLine("end");
        break;
    }
    Console.WriteLine("get message");
}
consumer.Close();