using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TelemetryAnalyzerAPI.Enums;

namespace TelemetryAnalyzerAPI.Models
{
    public class Satellite
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,
            ErrorMessage = "Invaild Name. It must be smaller then 100 nots")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(200, 40000,
            ErrorMessage = "Invalid Orbit Altitude, It must be between 200 to 40000 ")]
        public double OrbitAltitudeKm { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SatelliteStatus Status { get; set; }
    }
}
