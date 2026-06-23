using System;
namespace SignalInterceptLog;

enum Classification
{
    Friendly,
    Hostile,
    Unidentified
}

class LogManage
{

    static bool AddSignal(List<int> ids, List<Classification> classifications, List<double?> strengths, int id, Classification classification, double? strength)
    {
        ids.Add(id);
        classifications.Add(classification);
        strengths.Add(strength);
        return true;
    }

    static bool UpdateStrength(List<double?> strengths, int index, double? strength)
    {
        strengths[index] = strength;
        return true;
    }

    static void GetAllSignals(List<int> ids, List<Classification> classifications, List<double?> strengths)
    {
        Console.WriteLine("-Signales-");

        if (ids.Count == 0)
        {
            Console.WriteLine("No signals");
        }

        for (int i = 0; i < ids.Count; i++)
        {
            string message = $"Signal id: {ids[i]}\nClassification: {classifications[i]}\nstrength: {strengths[i]}";
            Console.WriteLine(message);
        }
    }

    static int? GetIndexOfSignal(List<int> ids, int id)
    { 
        for(int i = 0; i < ids.Count; i ++)
        {
            if (ids[i] == id)
            { return i; }
        }
        return null;
    }

    static int? CheckIsInt(string? stringNumber)
    {
        if (int.TryParse(stringNumber, out int number))
        {
            int? nullableNumber = number;
            return nullableNumber;
        }
        else
        {
            return null;
        }
    }

    static double? CheackIsDouble(string? stringNumber)
    {
        if (double.TryParse(stringNumber, out double number))
        {
            double? nullableNumber = number;
            return nullableNumber;
        }
        else
        {
            return null;
        }
    }

    static void PrintMenu()
    {
        string message = $"=== Signal Intercept Log ===\n" +
            $"Enter your choice:\n" +
            $"1.Add a signal\n" +
            $"2.calibration strength of a signal\n" +
            $"3.Show all signals\n" +
            $"4.Exit: ";
        Console.WriteLine(message);
    }

    static int? GetChoiceFromUser()
    {
        string? choice = Console.ReadLine();
        return CheckIsInt(choice);
        
        //if (nullableChoice.HasValue)
        //{
        //    int intChoice = nullableChoice.Value;

        //}
        
        //{

        //}
    }

    //static string PlayAction(int choice)
    //{ }

    static void Main()
    {
        List<int> ids = new List<int>();
        List<Classification> classifications = new List<Classification>();
        List<double?> strengths = new List<double?>();

        AddSignal(ids, classifications, strengths, 1, Classification.Friendly, 50.5);
        GetAllSignals(ids, classifications, strengths);
        //Console.WriteLine(GetIndexOfSignal(ids, 55));

        PrintMenu();

        GetChoiceFromUser();
    }

}

