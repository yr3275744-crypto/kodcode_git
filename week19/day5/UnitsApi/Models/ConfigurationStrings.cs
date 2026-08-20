using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsApi.Models
{
    public class ConfigurationStrings
    {
        public string bootstrapServers { get; set; } = string.Empty;
        public string uavTopic { get; set; } = string.Empty;
        public string hostileTopic { get; set; } = string.Empty;
        public string trackTopic { get; set; } = string.Empty;
        public string mysqlConnectionString { get; set; } = string.Empty;
        public string groupId { get; set; } = string.Empty;
    }
}
