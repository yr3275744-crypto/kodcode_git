using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Models
{
    public class SensorReading
    {
        public int SensorId { get; set; }
        public decimal Temperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
