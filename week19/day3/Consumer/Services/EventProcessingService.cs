using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Consumer.Data;
using Consumer.Models;
using Consumer.Models.Readings;
namespace Consumer.Services
{
    public class EventProcessingService
    {
        private readonly SmartCityDbContext _dbContext;
        public EventProcessingService(SmartCityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private bool ValidateTraffic(TrafficReading reading)
        {
            if (string.IsNullOrWhiteSpace(reading.Location))
            {
                return false;
            }
            if (reading.VehicleCount < 0 || reading.VehicleCount > 1000)
                return false;

            if (reading.Timestamp > DateTime.UtcNow.AddMinutes(5))
                return false;

            return true;

        }
        private bool ValidateWeather(WeatherReading reading)
        {
            if (string.IsNullOrWhiteSpace(reading.Location))
                return false;

            if (reading.TemperatureCelsius < -50 || reading.TemperatureCelsius > 60)
                return false; // Realistic temperature range

            if (reading.Humidity < 0 || reading.Humidity > 100)
                return false;

            if (reading.Timestamp > DateTime.UtcNow.AddMinutes(5))
                return false;

            return true;
        }

        private bool ValidateParking(ParkingReading reading)
        {
            if (string.IsNullOrWhiteSpace(reading.Location))
                return false;

            if (reading.AvailableSpots < 0 || reading.TotalSpots <= 0)
                return false;

            if (reading.AvailableSpots > reading.TotalSpots)
                return false; // Can't have more available than total

            if (reading.Timestamp > DateTime.UtcNow.AddMinutes(5))
                return false;

            return true;
        }

        public async Task<bool> ProcessTraficEventAsync(string jsonMessage)
        {
            try
            {
                // Deserialize
                var reading = JsonSerializer.Deserialize<TrafficReading>(jsonMessage);
                if (reading == null)
                {
                    Console.WriteLine("faild deseralize the event");
                    return false;
                }
                //Validate
                if (!ValidateTraffic(reading))
                {
                    Console.WriteLine($"Invalid obj {jsonMessage}");
                    return false;
                }
                //Transform to database model
                var trafficEvent = new TrafficEvent
                {
                    Location = reading.Location,
                    VehicleCount = reading.VehicleCount,
                    Timestamp = reading.Timestamp,
                    ProcessedAt = DateTime.UtcNow
                };
                // Save to database
                _dbContext.TrafficEvents.Add(trafficEvent);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("sucess");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> ProcessWeatherEventAsync(string jsonMessage)
        {
            try
            {
                var reading = JsonSerializer.Deserialize<WeatherReading>(jsonMessage);
                if (reading == null)
                {
                    Console.WriteLine("⚠ Failed to deserialize weather event");
                    return false;
                }

                if (!ValidateWeather(reading))
                {
                    Console.WriteLine($"⚠ Invalid weather event: {jsonMessage}");
                    return false;
                }

                var weatherEvent = new WeatherEvent
                {
                    Location = reading.Location,
                    TemperatureCelsius = reading.TemperatureCelsius,
                    Humidity = reading.Humidity,
                    Timestamp = reading.Timestamp,
                    ProcessedAt = DateTime.UtcNow
                };

                _dbContext.WeatherEvents.Add(weatherEvent);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"✓ Saved weather event: {reading.Location} - {reading.TemperatureCelsius}°C");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error processing weather event: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ProcessParkingEventAsync(string jsonMessage)
        {
            try
            {
                var reading = JsonSerializer.Deserialize<ParkingReading>(jsonMessage);
                if (reading == null)
                {
                    Console.WriteLine("⚠ Failed to deserialize parking event");
                    return false;
                }

                if (!ValidateParking(reading))
                {
                    Console.WriteLine($"⚠ Invalid parking event: {jsonMessage}");
                    return false;
                }

                var parkingEvent = new ParkingEvent
                {
                    Location = reading.Location,
                    AvailableSpots = reading.AvailableSpots,
                    TotalSpots = reading.TotalSpots,
                    Timestamp = reading.Timestamp,
                    ProcessedAt = DateTime.UtcNow
                };

                _dbContext.ParkingEvents.Add(parkingEvent);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"✓ Saved parking event: {reading.Location} - {reading.AvailableSpots}/{reading.TotalSpots}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error processing parking event: {ex.Message}");
                return false;
            }
        }

    }
}
