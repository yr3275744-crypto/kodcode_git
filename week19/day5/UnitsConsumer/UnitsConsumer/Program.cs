using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitsConsumer.Data;
using UnitsConsumer.Models;
using UnitsConsumer.Services;

class Program
{
    public async static Task Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        
        ConfigurationStrings conStrings = new ConfigurationStrings
        {
            bootstrapServers = config["Kafka:bootstrapServers"]!,
            uavTopic = config["Kafka:Topics:Uav"]!,
            hostileTopic = config["Kafka:Topics:Hostile"]!,
            trackTopic = config["Kafka:Topics:Track"]!,
            mysqlConnectionString = config["ConnectionStrings:MySql"]!,
            groupId = config["Kafka:GroupId"]!
        };
  

        serviceCollection.AddDbContext<AppDbContext>(options =>
        options.UseMySql(conStrings.mysqlConnectionString, ServerVersion.AutoDetect(conStrings.mysqlConnectionString)));

        serviceCollection.AddScoped<Proccessor>();
        serviceCollection.AddSingleton<ConfigurationStrings>();
        serviceCollection.AddSingleton<MyConsumer>(ps => new MyConsumer(conStrings.bootstrapServers,conStrings.groupId));

        var serviceProvider = serviceCollection.BuildServiceProvider();

        using (var scop = serviceProvider.CreateScope())
        {
            var db = scop.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.EnsureCreatedAsync();
            Console.WriteLine("Database fine");
        }
        using (var scop = serviceProvider.CreateScope())
        {
            var consumer = scop.ServiceProvider.GetRequiredService<MyConsumer>();
            var proccessor = scop.ServiceProvider.GetRequiredService<Proccessor>();
            var etl = new Etl(consumer, proccessor, conStrings);
            IEnumerable<string> topics = new List<string>()
            {
                conStrings.uavTopic,
                conStrings.hostileTopic,
                conStrings.trackTopic
            };
            foreach (string topic in topics)
            {
                await etl.LoopOverTopic(topic);
            }    
        }
    }
}