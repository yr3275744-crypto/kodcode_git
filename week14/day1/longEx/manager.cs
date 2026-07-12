using System;
using System.Collections.Generic;
using System.Text;

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
    public void Manege()
    {
        using (StreamReader sr = new StreamReader(SourceFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    Report report = new ParsToReport().Pars(line);
                }
                catch (InvalidLine ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidPriority ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }    
    }
}
