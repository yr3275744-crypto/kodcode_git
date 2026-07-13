using longEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LongEx;
    class ReportsLoader
{
        string Path { get; }
        public ReportsLoader(string path)
        {
            Path = path;
        }
    public List<Report> LoadReports()
    {
        string content = File.ReadAllText(Path);
        List<Report> reports = JsonSerializer.Deserialize<List<Report>>(content) ?? new();
        return reports;
    }
    }