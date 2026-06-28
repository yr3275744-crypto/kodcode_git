class Track
{
    public int Id;
    public double Speed;
    public double Heading;
    // full constructor — the one real setup lives here
    public Track(int id, double speed, double heading)
    {
        Id = id;
        Speed = speed;
        Heading = heading;
    }
    // overloaded + chained: forwards to the full one, no duplicated setup
    public Track(int id) : this(id, 0.0, 0.0) { }
}

class Program
{
    static void Main()
    {
        Track full = new Track(17, 412.5, 270);
        Track quick = new Track(8); // speed and heading default to 0
    }
}
