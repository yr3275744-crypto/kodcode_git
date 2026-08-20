using System.ComponentModel.Design;
using System.Security.Authentication.ExtendedProtection;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Producer.Models;
using Producer.Services;

namespace Producer;

public class Program
{
    public static async Task Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();

        string bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
        string analystTopic = configuration["Kafka:Topics:Analyst"] ?? "analyst-topic";
        string callTopic = configuration["Kafka:Topics:Call"] ?? "call-topic";

        ReadData<Analyst> readAnalysts = new ReadData<Analyst>();
        ReadData<Call> readCalls = new ReadData<Call>();

        MyProducer producer = new MyProducer(bootstrapServers);

        List<Analyst>? analysts = readAnalysts.ReadToObjectsList(@"Data\analysts.json");
        List<Call>? calls = readCalls.ReadToObjectsList(@"Data\calls.json");
        if (analysts != null)
        {
            Console.WriteLine("Read analysts success");
            foreach (Analyst analyst in analysts)
            {
                string key = Convert.ToString(analyst.analyst_id);
                string value = JsonSerializer.Serialize(analyst);
                await producer.SendAsync(analystTopic, key, value);
                Console.WriteLine($"analyst {key} send");
            }
        }
        if (calls != null)
        {
            Console.WriteLine("Read calls success");
            foreach (Call call in calls)
            {
                string key = Convert.ToString(call.call_id);
                string value = JsonSerializer.Serialize(call);
                await producer.SendAsync(callTopic, key, value);
                Console.WriteLine($"call {key} send");
            }
        }
        producer.Dispose();
    }
}

