using System;
namespace Blabla;

class Ex2
{
    static void Main()
    {
        Console.Write("Enter speed: ");
        string raw = Console.ReadLine();
        if (double.TryParse(raw, out double speed)) // true if it parsed, valuegoes into speed
{
            string band;
            if (speed < 200) band = "slow";
            else if (speed < 600) band = "cruise";
            else band = "fast";
            Console.WriteLine($"Speed {speed} -> {band}");
        }
        else
        {
            Console.WriteLine("That was not a number.");
        }
    }
}