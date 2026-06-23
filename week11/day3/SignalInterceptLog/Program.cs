using System;
using System.Dynamic;
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

    static int? GetId()
    {
        Console.WriteLine("Enter id: ");
        string? stringChoice = Console.ReadLine();

        if (int.TryParse(stringChoice, out int intId))
        {
            int? nullabaleId = intId;
            return intId;
        }
        else
        {
            return null;
        }
    }

    static Classification? GetClassfication()
    {
        Console.WriteLine("Enter the number of classification:\n" +
            "1.Friendly\n2.Hostile\n3.Unidentified");
        string? stringChoice = Console.ReadLine();

        Classification? nullabalClassification;

        switch (stringChoice)
        {
            case "1":
                nullabalClassification = Classification.Friendly;
                return nullabalClassification;
            
            case "2":
                nullabalClassification = Classification.Hostile;
                return nullabalClassification;

            case "3":
                nullabalClassification = Classification.Unidentified;
                return nullabalClassification;

            default:
                return null;
        }
    }

    static bool GetStrength(out double? nullableStrength)
    {
        Console.WriteLine("Enter strength, or unknown: ");
        string? stringChoice = Console.ReadLine();
        if (stringChoice == "unknown")
        {
            nullableStrength = null;
            return true;
        }
        else if (double.TryParse(stringChoice, out double strength))
        {
            nullableStrength = strength;
            return true;
        }
        else
        {
            nullableStrength = null;
            return false;
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
    }

    static string AddSignalHandle(List<int> ids, List<Classification> classifications, List<double?> strengths)
    {
        int? nullableId = GetId();
        if (nullableId is null)
        {
            return "Invalid id, You must enter  number";
        }

        Classification? nullabalClassification = GetClassfication();
        if (nullabalClassification is null)
        {
            return "invalid classification. you must enter 1, 2 or 3.";
        }
        
        double? nullableStrength;
        bool isValidStrength = GetStrength(out nullableStrength);
        if (isValidStrength is false)
        {
            return "invalid strength";
        }

        int id = nullableId.Value;
        Classification classification = nullabalClassification.Value;
        //double strength = nullableStrength.Value;
        bool isAdded = AddSignal(ids, classifications, strengths, id, classification, nullableStrength);
        if (isAdded)
        {
            return $"The signal {id} is added successfully";
        }
        else
        {
            return $"Filed to add the {id} signal.";
        }

    }

    static string PlayAction(int? choice, ref bool flag, List<int> ids, List<Classification> classifications, List<double?> strengths)
    { 
        switch (choice)
        {
            case 1:

                return AddSignalHandle(ids, classifications,strengths);

            case 3:
                GetAllSignals(ids, classifications, strengths);
                return "complite";

            case 4:
                flag = false;
                return "complite";

            default:
                return "This option id not available now.";
        }
    }

    static void Main()
    {
        List<int> ids = new List<int>();
        List<Classification> classifications = new List<Classification>();
        List<double?> strengths = new List<double?>();
        
        bool flag = true;
        
        while (flag)
        {
            PrintMenu();
            int? choice = GetChoiceFromUser();
            Console.WriteLine(PlayAction(choice, ref flag, ids, classifications, strengths));
        }



    }

}

