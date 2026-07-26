using Microsoft.AspNetCore.Mvc;
using WeatherStationApi.Models;

namespace WeatherStationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherReadingsController : ControllerBase
{
    private static readonly List<WeatherReading> _readings = new()
    {
        new WeatherReading
        {
        Id = 1,
        StationName = "Alpha",
        Location = "North",
        TemperatureCelsius = 22.5,
        HumidityPercent = 65,
        WindSpeedKmh = 12.3,
        RecordedAt = DateTime.UtcNow.AddHours(-2)
        },
        new WeatherReading
        {
        Id = 2,
        StationName = "Beta",
        Location = "South",
        TemperatureCelsius = 28.1,
        HumidityPercent = 72,
        WindSpeedKmh = 8.7,
        RecordedAt = DateTime.UtcNow.AddHours(-1)
        },
        new WeatherReading
        {
        Id = 3,
        StationName = "Gamma",
        Location = "East",
        TemperatureCelsius = 19.8,
        HumidityPercent = 58,
        WindSpeedKmh = 15.2,
        RecordedAt = DateTime.UtcNow.AddMinutes(-30)
        },
        new WeatherReading
        {
        Id = 4,
        StationName = "Delta",
        Location = "West",
        TemperatureCelsius = 25.3,
        HumidityPercent = 68,
        WindSpeedKmh = 10.1,
        RecordedAt = DateTime.UtcNow.AddMinutes(-15)
        },
        new WeatherReading
        {
        Id = 5,
        StationName = "Epsilon",
        Location = "North",
        TemperatureCelsius = 21.7,
        HumidityPercent = 61,
        WindSpeedKmh = 13.5,
        RecordedAt = DateTime.UtcNow.AddMinutes(-5)
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<WeatherReading>> GetAllReadings()
    {
        return Ok(_readings);
    }

    [HttpGet("{id}")]
    public ActionResult<WeatherReading> GetReadingById(int id)
    {
        var reading = _readings.FirstOrDefault(r => r.Id == id);
        if (reading == null)
        {
            return NotFound();
        }
        return Ok(reading);
    }

    [HttpGet("location/{location}")]
    public ActionResult<IEnumerable<WeatherReading>>
        GetReadingsByLocation(string location)
    {
        var readings = _readings.Where(r =>
        r.Location.Equals(location,
        StringComparison.OrdinalIgnoreCase)).ToList();

        return Ok(readings);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<WeatherReading>> SearchByTemperature(
    [FromQuery] double? minTemp,
    [FromQuery] double? maxTemp)
    {
        var query = _readings.AsEnumerable();
        if (minTemp.HasValue)
        {
            query = query.Where(r => r.TemperatureCelsius >= minTemp.Value);
        }
        if (maxTemp.HasValue)
        {
            query = query.Where(r => r.TemperatureCelsius <= maxTemp.Value);
        }
        return Ok(query.ToList());
    }
}