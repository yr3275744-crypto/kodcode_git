using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Consumer.Models
{
    public class Analyst
    {
        [Key]
        public int analyst_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string arena { get; set; } = string.Empty;
        public string specialty { get; set; } = string.Empty;

        public IEnumerable<Call> Calls { get; set; } = new List<Call>();
    }
}
