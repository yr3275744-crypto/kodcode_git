using System;
namespace ATrackedPlatformHierarchy;

abstract class Platform
{
    private int _trackId;
    private double _speedKnots;
    private double _heading;

    private int TrackId
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

    private double SpeedKnots
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

    private double Heading
    {
        get => _heading;
        set
        {
            if (value < 0 || value > 359)
            {
                _heading = 0;
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
}

class AirPlatform : Platform
{

}

class SeaPlatform : Platform
{

}

class GroundPlatform : Platform
{

}

class Program
{
    static void Main()
    {

    }
}