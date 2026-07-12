using System;
using System.Collections.Generic;
using System.Text;

namespace longEx
{
    class Report
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }

        public Report(int id, string category, int priority)
        {
            Id = id;
            Category = category;
            Priority = priority;
        }
        public override string ToString()
        {
            return $"Id: {Id}. Category:{Category}. Priority: {Priority}";
        }
    }
}
