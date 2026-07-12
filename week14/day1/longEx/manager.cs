using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace longEx;

class ReportsFileManager
{
    private string SourceFilePath { get; set; }
    private string TargetFilePath { get; set; }
    public ReportsFileManager(string sourceFilePath, string targetFilePath)
    {
        SourceFilePath = sourceFilePath;
        TargetFilePath = targetFilePath;
    }
    public void WriteReportsToFile(string targetPath, List<Report> reports)
    {
        using (StreamWriter sw = new StreamWriter(targetPath, true))
        {
            JsonSerializerOptions opts = new JsonSerializerOptions { WriteIndented = true };
            string jsonLine = JsonSerializer.Serialize(reports, opts);
            sw.Write(jsonLine);
        }
    }
    public void PrintReportsFromFile(string FilePath)
    {
        string lines = File.ReadAllText(FilePath);
        List<Report>? reports = JsonSerializer.Deserialize<List<Report>>(lines) ?? new List<Report>();
        foreach (Report report in reports)
        {
            Console.WriteLine(report.ToString());
        }

    }
    public void Manege()
    {
        int valids = 0;
        int total = 0;
        File.WriteAllText(TargetFilePath," ");
        List<Report> reports = new List<Report>();
        using (StreamReader sr = new StreamReader(SourceFilePath))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    Report report = new ParsToReport().Pars(line);
                    reports.Add(report);
                    valids++;

                }
                catch (InvalidArgomentsNumber ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidPriority ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    total++;
                }
            }
            WriteReportsToFile(TargetFilePath, reports);
            Console.WriteLine($"valids: {valids}, in valids: {total - valids}");
            PrintReportsFromFile(TargetFilePath);
        } 
    }
}
