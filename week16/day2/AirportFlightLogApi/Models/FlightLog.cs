using System.ComponentModel.DataAnnotations;

namespace AirportFlightLogApi.Models;

public class FlightLog
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Flight number is required")]
    [StringLength(10, MinimumLength = 3,
        ErrorMessage = "Flight number must be between 3 and 10 characters")]
    public string FlightNumber { get; set; } = "";

    [Required(ErrorMessage = "Airline is required")]
    [StringLength(50,
        ErrorMessage = "Airline name cannot exceed 50 characters")]
    public string Airline { get; set; } = "";

    [Required(ErrorMessage = "Destination is required")]
    [StringLength(100,
        ErrorMessage = "Destination cannot exceed 100 characters")]
    public string Destination { get; set; } = "";

    [Range(1, 1000,
        ErrorMessage = "Passenger count must be between 1 and 1000")]
    public int PassengerCount { get; set; }

    [Required(ErrorMessage = "Departure time is required")]
    public DateTime ScheduledDeparture { get; set; }
    public DateTime? ActualDeparture { get; set; }

    [StringLength(500,
        ErrorMessage = "Remarks cannot exceed 500 characters")]
    public string? Remarks { get; set; }
    public string Status { get; set; } = "Scheduled";
}
