using Producer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Producer.Services
{
    public class DataLoaderService
    {
        public List<TrafficReading>? LoadTrafficData(string filePath)
        {
            string raw = File.ReadAllText(filePath);
            List<TrafficReading>? traffics = JsonSerializer.Deserialize<List<TrafficReading>>(raw);
            return traffics;
        }
        public List<WeatherReading>? LoadWeatherData(string filePath)
        {
            string raw = File.ReadAllText(filePath);
            List<WeatherReading>? weathers = JsonSerializer.Deserialize<List<WeatherReading>>(raw);
            return weathers;
        }
        public List<ParkingReading>? LoadParkingData(string filePath)
        {
            string raw = File.ReadAllText(filePath);
            List<ParkingReading>? parkings = JsonSerializer.Deserialize<List<ParkingReading>>(raw);
            return parkings;
        }
    }
}
