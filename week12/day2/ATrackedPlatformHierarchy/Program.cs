using System;
namespace ATrackedPlatformHierarchy;

abstract class Platform
{
    private int _trackId;
    private double _speedKnots;
    private double _heading;

    protected int TrackId
    {
        get => _trackId;
        set
        {
            if (value <= 0)
            {
                _trackId = 0;
            }
            else
            {
                _trackId = value;
            }
        }
    }

    protected double SpeedKnots
    {
        get => _speedKnots;
        set
        {
                if (value < 0)
                {
                _speedKnots = 0;
                }
                else
                {
                _speedKnots = value;
                }
        }
    }

    protected double Heading
    {
        get => _heading;
        set
        {
            if (value < 0 || value > 359)
            {
                _heading = 0.0;
            }
            else
            {
                _heading = value;
            }
        }
    }


    protected Platform(int trackId, double speedKnots, double heading) 
    {
        TrackId = trackId;
        SpeedKnots = speedKnots;
        Heading = heading;
    }

    public abstract string StatusLine();

    public abstract bool IsTrackable();

    public override string ToString()
    {
        return $"Id: {TrackId} | Speed: {SpeedKnots} | Heading: {Heading}";
    }
}

class AirPlatform : Platform
{
    private double _altitudeFeet;

    private double AltitudeFeet
    {
        get => _altitudeFeet;
        set
        {
            if (value < 0)
            {
                _altitudeFeet = 0.0;
            }
            else
            {
                _altitudeFeet = value;
            }
        }
    }

    public AirPlatform(int trackId, double speedKnots, double heading, double altitudeFeet) : base(trackId, speedKnots, heading)
    {
        AltitudeFeet = altitudeFeet;
    }

    public override string StatusLine()
    {
        return $"Air platform number: {TrackId}\n" +
            $"Speed: {SpeedKnots}\n" +
            $"Heading: {Heading}\n" +
            $"Altitude feet: {AltitudeFeet}";
    }

    public override bool IsTrackable()
    {
        if (AltitudeFeet > 100 && AltitudeFeet < 60000 && SpeedKnots > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class SeaPlatform : Platform
{
    private double _depthMeters;

    private double DepthMeters
    {
        get => _depthMeters;
        set
        {
            if (value < 0)
            {
                _depthMeters = 0.0;
            }
            else
            {
                _depthMeters = value;
            }
        }
    }
    public SeaPlatform(int trackId, double speedKnots, double heading, double depthMeters) : base(trackId, speedKnots, heading)
    {
        DepthMeters = depthMeters;
    }
    public override string StatusLine()
    {
        return $"Sea platform number: {TrackId}\n" +
            $"Speed: {SpeedKnots}\n" +
            $"Heading: {Heading}\n" +
            $"Depth meters: {DepthMeters}";
    }

    public override bool IsTrackable()
    {
        if (DepthMeters > 0 && DepthMeters < 300)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class GroundPlatform : Platform
{
    private string? _terrainType;

    private string? TerrainType
    {
        get => _terrainType;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _terrainType = "unknown";
            }
            else
            {
                _terrainType = value;
            }
        }
    }

    public GroundPlatform(int trackId, double speedKnots, double heading, string? terrainType) : base(trackId, speedKnots, heading)
    {
        TerrainType = terrainType;
    }
    public override string StatusLine()
    {
        return $"Ground platform number: {TrackId}\n" +
            $"Speed: {SpeedKnots}\n" +
            $"Heading: {Heading}\n" +
            $"Terrain type: {TerrainType}";
    }

    public override bool IsTrackable()
    {
        if (TerrainType != "tunnel")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        List<Platform> platformList = new List<Platform>();
        AirPlatform airPlatform1 = new AirPlatform(1, 150, 340, 40000);
        AirPlatform airPlatform2 = new AirPlatform(2, 100, 340, 50);
        SeaPlatform seaPlatform1 = new SeaPlatform(1, 300.3, 250, 500);
        SeaPlatform seaPlatform2 = new SeaPlatform(2, 500, 700, 200);
        GroundPlatform groundPlatform1 = new GroundPlatform(1, 100.5, 540.2, "uy");
        GroundPlatform groundPlatform2 = new GroundPlatform(2, 0, 72.5, "tunnel");

        platformList.Add(airPlatform1);
        platformList.Add(airPlatform2);
        platformList.Add(seaPlatform1);
        platformList.Add(seaPlatform2);
        platformList.Add(groundPlatform1);
        platformList.Add(groundPlatform2);

        foreach (Platform val in platformList)
        {
            Console.WriteLine(val.ToString());
            Console.WriteLine(val.StatusLine());
            Console.WriteLine($"Is trackable: {val.IsTrackable()}");
        }
    }
}