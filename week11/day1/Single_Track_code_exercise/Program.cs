using System;
namespace SingleTrack;

class TrackManager
{
    static void Main()
    {
        bool flag = true;
        double doubleId = 0.0;
        int intResult = 0;
        double doubleResult = 0;
        string category = "";
        int speedIntResoult = 0;
        double speedDoubleResoult = 0.0;

        Console.Write("Enter the Track Id: ");
        string? idString = Console.ReadLine();

        Console.Write("Enter the Speed: ");
        string? sppedString = Console.ReadLine();

        Console.Write("Enter the Heading: ");
        string? headingString = Console.ReadLine();

        Console.Write("Enter the Status: ");
        string? status = Console.ReadLine();

        if (int.TryParse(idString, out int id))
        {
            doubleId = (double)id;
            intResult = id / 10;
            doubleResult = doubleId / 10.0;
        }
        else { Console.WriteLine("invalid Track id");
        flag = false;}

        if (double.TryParse(sppedString, out double speed))
        {
                    
            if (speed < 100)
            { category = "slow"; }
                    
            else if (speed < 300)
            { category = "mesium"; }
                    
            else
            { category = "fast"; }

        speedIntResoult = (int)speed / 60;
        speedDoubleResoult = speed / 60.0;
        }
        else { Console.WriteLine("invalid Speed.");
        flag = false;}

        if (double.TryParse(headingString, out double heading))
        {
            if (heading >= 0 & heading <= 359)
            { }
            else { Console.WriteLine("Worning: High heading!");}
        }

        else { Console.WriteLine("Invalid heading. Invalid heading. You must enter a number");
        flag = false;}

        if (status == "cruising" | status == "turning" | status == "stopped" | status == "accelerating")
            { }
                
        else { Console.WriteLine("Invalid status"); 
        flag = false;}

        if (flag)
        {
            Console.WriteLine($"=== Track Report ===\n" +
                $"Track ID: {id}\n" +
                $"Speed: {speed} km/h ({category})\n" +
                $"Heading: {heading} degrees\n" +
                $"Status: {status}\n" +
                $"Division Demo 1: {id} / 10 = {intResult} (int) | {doubleResult} (double)\n" +
                $"Division Demo 2: {speed} / 60 = {speedIntResoult} (int) | {speedDoubleResoult} (double)\n");
            
        }
    }

}