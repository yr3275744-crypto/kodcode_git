using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models.Readings
{
    public class ParkingReading : Reading
    {
        public string Location { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int AvailableSpots { get; set; }
        public int TotalSpots { get; set; }

    }
}
