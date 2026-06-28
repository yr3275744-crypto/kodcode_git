using System;
namespace example2;

class Track
{
    public int Id;
    public Track(int id) { Id = id; }
}

class Program
{
    static void Main()
    {
        Track t = new Track(17); // you must use the one you wrote
    }
}
// Track t = new Track(); // <- now this FAILS to compile

