using TelemetryAnalyzerAPI.Models;

namespace TelemetryAnalyzerAPI.Exceptions
{
    public class SatelliteNotFoundException : Exception
    {
        public int SatelliteId { get; set; }
        public SatelliteNotFoundException(int satelliteId)
            : base("Satellite {id} not found.")
        {
            SatelliteId = satelliteId;
        }
    }
}
