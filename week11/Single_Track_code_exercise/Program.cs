using System;
namespace SingleTrack;

class TrackManager
{
    static void Main()
    {
        bool flag = true;
        while (flag)
            {
                Console.Write("Enter the Track Id: ");
                string? idString = Console.ReadLine();

                Console.Write("Enter the Speed: ");
                string? sppedString = Console.ReadLine();

                Console.Write("Enter the Heading: ");
                string? headingString = Console.ReadLine();

                Console.Write("Enter the Status: ");
                string? status = Console.ReadLine();

                if (int.TryParse(idString, out int id))
                { }
                else { Console.WriteLine("invalid Track id");
                flag = false;}

                if (double.TryParse(sppedString, out double speed))
                { 
                    string category;
                    
                    if (speed < 100)
                    { category = "slow"; }
                    
                    else if (speed < 300)
                    { category = "mesium"; }
                    
                    else
                    { category = "fast"; }
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

                flag = false;
            }
    }

}