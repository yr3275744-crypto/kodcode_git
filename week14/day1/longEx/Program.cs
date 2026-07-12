using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace longEx;

class Program
{
    static void Main()
    {
        try
        {
            ReportsFileManager reportsFileManager = new ReportsFileManager(@"w4d1_field_reports_input.txt", @"result.txt");
            reportsFileManager.Manege();
            reportsFileManager.PrintReportsFromFile(@"w4d1_reports_corrupted.txt");
        }
        catch (JsonException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

        }

    }
}