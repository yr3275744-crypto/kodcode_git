using System;
namespace Exampel1;

class program
{
    class Track
    {
        public int Id; // a field (we will make this private soon)
        public double Speed;
        public Track(int id, double speed) // constructor: runs on `new`
        {
            Id = id;
            Speed = speed;
            Console.WriteLine("constructor ran"); // proof it fired
        }
    }

    static void Main()
    {
        Track a = new Track(17, 412.5);
        Track b = new Track(8, 95.0);
        Console.WriteLine($"{a.Id} at {a.Speed} kn");
        Console.WriteLine($"{b.Id} at {b.Speed} kn");
    }
}


