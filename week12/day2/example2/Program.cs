using System.Runtime.ConstrainedExecution;

class Track
{
    public int Id { get; }
    public Track(int id) { Id = id; }
    public virtual string Describe() // virtual: a derived class MAY replace it
=> $"Track {Id}";
}
class Aircraft : Track
{
    public double Altitude { get; }
    public Aircraft(int id, double altitude) : base(id)
    {
        Altitude = altitude;
    }
    public override string Describe() // override: this kind replaces the behavior
=> $"Aircraft {Id} at {Altitude} ft";
}

class Program
{
    static void Main()
    {
        Aircraft a = new Aircraft(1, 30000);
        Console.WriteLine(a.Describe());
        Track b = new Track(5);
        Console.WriteLine(b.Describe());
    }
}