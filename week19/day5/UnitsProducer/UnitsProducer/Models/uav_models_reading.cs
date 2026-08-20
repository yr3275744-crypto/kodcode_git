using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsProducer.Models
{
    public class uav_models_reading
    {
        public int model_id { get; set; }
        public string model_name { get; set; } = string.Empty;

        [AllowedValues([
            "small",
            "medium",
            "large"
            ])]
        public string model_class { get; set; } = string.Empty;
        public int max_range_km { get; set; }
        public int endurance_minutes { get; set; }
        public string sensor_payload { get; set; } = string.Empty;

    }
}
