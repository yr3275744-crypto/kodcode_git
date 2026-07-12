using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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

            }
        }
    }
}