using Microsoft.Extensions.Configuration;
using UnitsProducer.Models;
using UnitsProducer.Services;

class Program
{
    public async static Task Main()
    {
        LoadFiles<uav_models_reading> uavsLoader = new();
        LoadFiles<hostile_units_reading> hostilLoader = new();
        LoadFiles<tracks_reading> trackLoader = new();
        List<uav_models_reading>? uavs = uavsLoader.Read(@"Data\uav_models.json");
        List<hostile_units_reading>? hostiles = hostilLoader.Read(@"Data\hostile_units.json");
        List<tracks_reading>? tracks = trackLoader.Read(@"Data\tracks.json");

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetings.json")
            .Build();
        string bootstrapServers = config["Kafka:bootstrapServers"]!;
        string uavTopic = config["Kafka:Topics:Uav"]!;
        string hostileTopic = config["Kafka:Topics:Hostile"]!;
        string trackTopic = config["Kafka:Topics:Track"]!;

        var producer = new MyProducer(bootstrapServers);


            if (uavs != null)
        {
            foreach (uav_models_reading uav in uavs)
            {
                await producer.SendUavAsync(uav, uavTopic);
                Console.WriteLine("uav send");
            }
        }
        if (hostiles != null)
        {
            foreach (hostile_units_reading hostile in hostiles)
            {
                await producer.SendHostileAsync(hostile, hostileTopic);
                Console.WriteLine("hostile send");
            }
        }
        if (tracks != null)
        {
            foreach (tracks_reading track in tracks)
            {
                await producer.SendTrackAsync(track, trackTopic);
                Console.WriteLine("track send");
            }
        }
        producer.Dispose();

    }
}