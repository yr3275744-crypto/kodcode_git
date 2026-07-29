namespace TelemetryAnalyzerAPI.Exceptions
{
    public class CriticalTelemetryException : Exception
    {
        public int SatelliteId { get; set; }
        public string Reason { get; set; }
        public CriticalTelemetryException(int satelliteId, string reason)
            : base("In Satellite {id}, Critical Telemetry Exception. The reason: {reason}")
        {
            SatelliteId = satelliteId;
            Reason = reason;
        }

    }
}
