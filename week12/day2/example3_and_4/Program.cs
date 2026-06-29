abstract class Track // abstract: a Track "in general" cannot exist
{
public int Id { get; }
public double Speed { get; set; }
protected Track(int id, double speed) // base constructor for derived classes
{
Id = id;
Speed = speed;
}
public abstract string Describe(); // no body — every kind MUST implement it
}
class Aircraft : Track
{
    public double Altitude { get; }
    public Aircraft(int id, double speed, double altitude)
    : base(id, speed) => Altitude = altitude;
    public override string Describe()
    => $"Aircraft {Id} at {Altitude} ft, {Speed} kn";
}
class Vessel : Track
{
    public Vessel(int id, double speed) : base(id, speed) { }
    public override string Describe()
    => $"Vessel {Id}, {Speed} kn";
}
 // <- compile error: cannot create an abstract class
//Severity Code Description Project File Line Suppression State
//Error (active) CS0144 Cannot create an instance of the abstract type or
//interface 'Track' W2D2 D:\C#Projects\W2D2\Program.cs 34

class Program
{
    static  void Main()
    {
        Aircraft a = new Aircraft(1, 420, 30000);
        Console.WriteLine(a.Describe());
        Vessel b = new Vessel(5, 120);
        Console.WriteLine(b.Describe());
        //Track t = new Track(1, 100);
    }
}
