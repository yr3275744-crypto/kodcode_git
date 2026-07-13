using longEx;
using LongEx;
using System;

class Program
{
    static void Main()
    {
        ReportsLoader reportsLoader = new ReportsLoader(@"reports.json");
        List<Report> reports = reportsLoader.LoadReports();
        QueryReports queryReports = new QueryReports(reports);
        //queryReports.PrintFilteringAndProgection();
        //queryReports.PrintOrderingAndSlicing();
        queryReports.PrintAggrigation();
    }
}