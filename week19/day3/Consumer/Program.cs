using Confluent.Kafka;
using Consumer.Data;
using Consumer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

class Program
{
    private static void CreateDatabase(ServiceProvider provider)
    {
        Console.WriteLine("Creating Database..");
        using (var scope = provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<SmartCityDbContext>();
            db.Database.EnsureCreated();
            Console.WriteLine("Database ready");
        }
    }
    private static IConsumer<Ignore, string> ConfigKafkaConsumer(IConfiguration configuration)
    {
        var conduserConfig = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = configuration["Kafka:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };
        IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(conduserConfig).Build();
        {
            var topics = new[]
            {
                configuration["Kafka:Topics:Traffic"],
                configuration["Kafka:Topics:Weather"],
                configuration["Kafka:Topics:Parking"]
            };
            consumer.Subscribe(topics);
            Console.WriteLine($"Subscribed to: {string.Join(", ", topics)}");
            return consumer;
        }
    }

    private static async Task ConsumeLoop(
        IConsumer<Ignore, string> consumer,
        ServiceProvider serviceProvider,
        IConfiguration configuration
        )
    {
        while (true)
        {
            ConsumeResult<Ignore, string>? result = consumer.Consume(TimeSpan.FromSeconds(1));
            if (result == null || result.Message?.Value == null)
            {
                continue;
            }
            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] Received from {result.Topic}");

            // Create a new scope for this message
            // This gives us a fresh DbContext
            using (var scope = serviceProvider.CreateScope())
            {
                var processingService = scope.ServiceProvider
                    .GetRequiredService<EventProcessingService>();

                // Route to the correct processing method based on topic
                if (result.Topic == configuration["Kafka:Topics:Traffic"])
                {
                    await processingService.ProcessTraficEventAsync(result.Message.Value);
                }
                if (result.Topic == configuration["Kafka:Topics:Weather"])
                {
                    await processingService.ProcessWeatherEventAsync(result.Message.Value);
                }
                if (result.Topic == configuration["Kafka:Topics:Parking"])
                {
                    await processingService.ProcessParkingEventAsync(result.Message.Value);
                }
                consumer.Commit(result);
                Console.WriteLine("Get teh message");
            }

        }

    }
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Start");

        //configuration - extention
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();

        //connection string
        string connectionString = configuration.GetConnectionString("SmartCityDb") ?? "";
        Console.WriteLine(connectionString);

        // services collection
        var services = new ServiceCollection();

        // add dbContext
        services.AddDbContext<SmartCityDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        //add service
        services.AddScoped<EventProcessingService>();

        //add DI container (provider)
        ServiceProvider serviceProvider = services.BuildServiceProvider();

        CreateDatabase(serviceProvider);

        var consumer = ConfigKafkaConsumer(configuration);

        try
        {

            await ConsumeLoop(consumer, serviceProvider, configuration);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Shutting down gracefully...");
        }
        finally
        {
            consumer.Close();
        }
    }

}