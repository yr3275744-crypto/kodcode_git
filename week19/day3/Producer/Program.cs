//to do: check if the current directory to configuration json extantion works in the container
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Producer.Models;
using Producer.Services;

DataLoaderService dataLoader = new DataLoaderService();

var parkings = dataLoader.LoadParkingData("Data/parking-data.json");
foreach (ParkingReading parking in parkings)
{
    Console.WriteLine(parking.ToString());
}

var traffics = dataLoader.LoadTrafficData("Data/traffic-data.json");
foreach (TrafficReading t in traffics)
{
    Console.WriteLine(t.ToString());
}

var weathers = dataLoader.LoadWeatherData("Data/weather-data.json");
foreach (WeatherReading w in weathers)
{
    Console.WriteLine(w.ToString());
}

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "non";
List<string> topics = new List<string>
{
    configuration["Topics:Trafic"] ?? "traffic-events",
    configuration["Topics:Weather"] ?? "weather-events",
    configuration["Topics:Parking"] ?? "parking-events"
};

Console.WriteLine(bootstrapServers);

KafkaProducerService kafkaProducer = new KafkaProducerService(bootstrapServers);

for (int i = 0; i < traffics.Count || i < parkings.Count || i < weathers.Count; i++)
{
    if (i < traffics.Count)
    {
        //await Task.Delay(2000);
        var result = await kafkaProducer.SendAsync<TrafficReading>(topics[0], traffics[i]);
    }
    if (i < weathers.Count)
    {
        //await Task.Delay(2000);
        var result = await kafkaProducer.SendAsync<WeatherReading>(topics[1], weathers[i]);
    }
    if (i < parkings.Count)
    {
        //await Task.Delay(2000);
        var result = await kafkaProducer.SendAsync<ParkingReading>(topics[2], parkings[i]);
    }
}
Console.WriteLine("success");
kafkaProducer.Dispose();