using AirportFlightLogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportFlightLogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightLogsController : ControllerBase
{
    private static readonly List<FlightLog> _flightLogs = new()
    {
        new FlightLog
        {
        Id = 1,
        FlightNumber = "AA101",
        Airline = "American Airlines",
        Destination = "New York JFK",
        PassengerCount = 180,
        ScheduledDeparture = DateTime.UtcNow.AddHours(2),
        Status = "Scheduled"
        },
        new FlightLog
        {
        Id = 2,
        FlightNumber = "BA202",
        Airline = "British Airways",
        Destination = "London Heathrow",
        PassengerCount = 250,
        ScheduledDeparture = DateTime.UtcNow.AddHours(4),
        ActualDeparture = DateTime.UtcNow.AddHours(4).AddMinutes(15),
        Status = "Departed",
        Remarks = "Delayed due to weather"
        },
        new FlightLog
        {
        Id = 3,
        FlightNumber = "LH303",
        Airline = "Lufthansa",
        Destination = "Frankfurt",
        PassengerCount = 200,
        ScheduledDeparture = DateTime.UtcNow.AddHours(6),
        Status = "Scheduled"
        }
    };

    private static int _nextId = 4;

    [HttpGet]
    public ActionResult<IEnumerable<FlightLog>> GetAllFlightLogs()
    {
        return Ok(_flightLogs);
    }

    [HttpGet("{id}")]
    public ActionResult<FlightLog> GetById(int id)
    {
        FlightLog? log = _flightLogs.FirstOrDefault(log => log.Id == id);
        if (log == null)
        {
            return NotFound();
        }
        return Ok(log);
    }

    [HttpPost]
    public ActionResult<FlightLog> CreateFlightLog(FlightLog flightLog)
    {
        flightLog.Id = _nextId;
        _flightLogs.Add(flightLog);
        return CreatedAtAction(
            nameof(GetById),
            new { id = flightLog.Id },
            flightLog);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFligtLog(int id, FlightLog updatedLog)
    {
        var existingLog = _flightLogs.FirstOrDefault(l => l.Id == id);
        if (existingLog == null)
        {
            return NotFound();
        }
        existingLog.FlightNumber = updatedLog.FlightNumber;
        existingLog.Airline = updatedLog.Airline;
        existingLog.Destination = updatedLog.Destination;
        existingLog.PassengerCount = updatedLog.PassengerCount;
        existingLog.ScheduledDeparture = updatedLog.ScheduledDeparture;
        existingLog.ActualDeparture = updatedLog.ActualDeparture;
        existingLog.Remarks = updatedLog.Remarks;
        existingLog.Status = updatedLog.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFlightLog(int id)
    {
        var log = _flightLogs.FirstOrDefault(l => l.Id == id);
        if (log == null)
        {
            return NotFound();
        }
        _flightLogs.Remove(log);
        return NoContent();
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<FlightLog>> SearchByAirline(
        [FromQuery] string airline)
    {
        if (string.IsNullOrWhiteSpace(airline))
        {
            return BadRequest("Airline parameter cannot be empty");
        }
        var logs = _flightLogs
            .Where(log => log.Airline.Contains(airline, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Ok(logs);
    }

}
