using longEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LongEx;
class QueryReports
{
    public List<Report> Reports { get; }
    public QueryReports(List<Report> reports)
    {
        Reports = reports;
    }
    public void PrintFilteringAndProgection()
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
        var specificSignalStrengths = Reports.Where(report => report.SignalStrength >= 70 && report.SignalStrength <= 90)
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
    public void PrintOrderingAndSlicing()
    {
        var orderPriority = Reports.OrderBy(report => report.Priority)
            .Select(report => new { Id = report.Id });
        var orederZoneAndPriority = Reports.OrderBy(report => report.Zone)
            .ThenByDescending(report => report.Priority);
        var hiest3 = Reports.OrderByDescending(report => report.SignalStrength)
            .Take(3)
            .Select(report => new { Id = report.Id });
        var wikest2 = Reports.OrderBy(report => report.SignalStrength)
            .Take(2)
            .Select(report => new { Id = report.Id });
        foreach (var row in orderPriority)
        {
            Console.WriteLine($"Orderd by priority, id:{row.Id}");
        }
        foreach (var row in orederZoneAndPriority)
        {
            Console.WriteLine($"Orderd by zone and priority, id:{row.Id}");
        }
        foreach (var row in hiest3)
        {
            Console.WriteLine($"The 3 highest reports, id:{row.Id}");
        }
        foreach (var row in wikest2)
        {
            Console.WriteLine($"The 2 wikest reports, id:{row.Id}");
        }
    }
    public void PrintAggrigation()
    {
        int HighestPriorityCount = Reports.Count(report => report.Priority == 5);
        int h1 = Reports.Max(report => report.SignalStrength);
        int w1 = Reports
            .Where(report => report.Shift == "Night")
            .Min(report => report.SignalStrength);
        Console.WriteLine($"HighestPriorityCount: {HighestPriorityCount}");
        Console.WriteLine($"max: {h1}");
        Console.WriteLine($"min night: {w1}");
    }
}

