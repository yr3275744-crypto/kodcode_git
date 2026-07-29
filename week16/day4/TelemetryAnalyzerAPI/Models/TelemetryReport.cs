using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace TelemetryAnalyzerAPI.Models;

public class TelemetryReport
{
    public int Id { get; set; }

    [Required]
    public int SatelliteId { get; set; }

    [Required]
    [Range(0, 100,
        ErrorMessage = "Invalid Battery percent, it must be between 0 to 100")]
    public double BatteryPercent { get; set; }

    [Required]
    [Range(-100, 100,
        ErrorMessage = "Invalid Temperature Celsiust, it must be between -100 to 100")]
    public double TemperatureCelsius { get; set; }

    [Required]
    [Range(-120, 0,
       ErrorMessage = "Invalid Signal strengh, it must be between -120 to 0")]
    public double SignalStrengthDb { get; set; }
    public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Normal";
}
