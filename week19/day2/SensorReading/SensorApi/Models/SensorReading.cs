namespace SensorApi.Models
{
    public class SensorReading
    {
        public int SensorId { get; set; }
        public decimal Temperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
