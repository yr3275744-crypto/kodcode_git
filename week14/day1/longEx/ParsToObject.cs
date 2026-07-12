using System;
using System.Collections.Generic;
using System.Text;

namespace longEx;
class ParsToReport
{
    public Report Pars(string line)
    {
        string[] splitedLine = line.Split(" ");
        if (splitedLine.Length != 3)
        {
            throw new InvalidLine("line must have exactly 3 arguments.");
        }
        int id = int.Parse(splitedLine[0]);
        string category = splitedLine[1];
        int priority = int.Parse(splitedLine[2]);
        if (priority < 0)
        {
            throw new InvalidPriority("priority must be bigger then 0");
        }
        return new Report(id, category, priority);
    }
}

