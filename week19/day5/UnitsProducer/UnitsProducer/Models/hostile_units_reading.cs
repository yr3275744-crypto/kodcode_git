using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsProducer.Models
{
    public class hostile_units_reading
    {
        public int unit_id { get; set; }
        public int model_id { get; set; }
        public string operator_name { get; set; } = string.Empty;
        public DateTime first_seen_date { get; set; }

        [AllowedValues([
            "active",
            "lost",
            "destroyed"
            ])]
        public string status { get; set; } = string.Empty;
        public double home_lat { get; set; }
        public double home_lon { get; set; }
    }
}
