using System;
using System.Collections.Generic;
using System.Text;

namespace longEx;
    class Report
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public string Zone { get; set; }
        public int SignalStrength { get; set; }
        public string Shift { get; set; } 

        public Report(int id, string category, int priority, string zone, int signalStrength, string shift)
        {
            Id = id;
            Category = category;
            Priority = priority;
            Zone = zone;
            SignalStrength = signalStrength;
            Shift = shift;
        }
        public override string ToString()
        {
            return $"Id: {Id}. Category:{Category}. Priority: {Priority}";
        }
    }