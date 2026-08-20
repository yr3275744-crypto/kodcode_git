using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConsumer.Models.Readings
{
    public class tracks_reading
    {
        public int track_id { get; set; }
        public int unit_id { get; set; }
        public DateTime report_time { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int altitude_m { get; set; }

        [Range(0, 100)]
        public int signal_strength { get; set; }

    }
}
