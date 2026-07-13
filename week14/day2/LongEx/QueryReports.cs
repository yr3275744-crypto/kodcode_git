using longEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LongEx;
class QueryReports
{
    public List<Report> Reports { get; }
    public QueryReports(List<Report> reports)
    {
        Reports = reports;
    }
    public void PrintFilteringAndProgectionQueries()
    {
        int totalCount = Reports.Count();
        
        var signalIds = Reports.Where(report => report.Category == "SIGNAL")
            .Select(report => new {Id = report.Id});
        var highersPriorityIds = Reports.Where(report => report.Priority >= 4)
            .Select(report => new {Id = report.Id});
        var nightNorthReportsIds = Reports.Where(report => report.Shift == "Night" && report.Zone == "North")
            .Select(report => new {Id = report.Id});
        var commsIdAndPriority = Reports.Where(report => report.Category == "COMMS")
            .Select(report => new { Id = report.Id, Priority = report.Priority });
        var specificSignalStrengths = Reports.Where(report => report.SignalStrength <= 70 && report.SignalStrength <= 90)
            .Select(report => new { Id = report.Id });
        var notWestZone = Reports.Where(report => report.Zone != "West")
            .Select(report => new { Id = report.Id });

        Console.WriteLine($"Total reports: {totalCount}");

        foreach (var row in signalIds)
        {
            Console.WriteLine($"Signal report. id:{row.Id}");
        }
        foreach (var row in highersPriorityIds)
        {
            Console.WriteLine($"High priority. id:{row.Id}");
        }
        foreach (var row in nightNorthReportsIds)
        {
            Console.WriteLine($"Night-shift reports in the North zone. id:{row.Id}");
        }
        foreach (var row in commsIdAndPriority)
        {
            Console.WriteLine($"COMMS report. id:{row.Id}. priority: {row.Priority}");
        }
        foreach (var row in specificSignalStrengths)
        {
            Console.WriteLine($"SignalStrength is between 70 and 90. id:{row.Id}");
        }
        foreach (var row in notWestZone)
        {
            Console.WriteLine($"reports that are not in the West zone. id:{row.Id}");
        }
    }
}

