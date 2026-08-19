using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Models
{
    public class WeatherReading : Reading
    {
        public string Location { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        public decimal TemperatureCelsius { get; set; }
        public int Humidity { get; set; }

    }
}
