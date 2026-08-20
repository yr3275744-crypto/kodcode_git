using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Models
{
    public class Analyst
    {
        public int analyst_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string arena { get; set; } = string.Empty;
        public string specialty { get; set; } = string.Empty;
    }
}
