using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class CallReading
    {
        public int analyst_id { get; set; }
        public int call_id { get; set; }
        public int agent_id { get; set; }
        //public bool word_alpha { get { return word_alpha; } set { word_alpha = (bool)value; } }
        public int word_alpha { get; set; }
        public int word_bravo { get; set; }
        public int word_charlie { get; set; }
    }
}
