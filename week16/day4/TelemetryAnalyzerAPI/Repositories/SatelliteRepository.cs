using TelemetryAnalyzerAPI.Enums;
using TelemetryAnalyzerAPI.Models;
using TelemetryAnalyzerAPI.Repositories.Interfaces;

namespace TelemetryAnalyzerAPI.Repositories;

public class SatelliteRepository : ISatelliteRepository
{

    private int _nextId = 11;
    private readonly List<Satellite> _satellites = new List<Satellite>
    {
        new Satellite
        {
            Id = 1,
            Name = "Horizon-1",
            OrbitAltitudeKm = 550,
            Status = SatelliteStatus.Active
        },
        new Satellite
        {
            Id = 2,
            Name = "Explorer-X",
            OrbitAltitudeKm = 1200,
            Status = SatelliteStatus.Active
        },
        new Satellite
        {
            Id = 3,
            Name = "SkyWatch",
            OrbitAltitudeKm = 750,
            Status = SatelliteStatus.Decommissioned
        },
        new Satellite
        {
            Id = 4,
            Name = "Orbiter-A",
            OrbitAltitudeKm = 35786,
            Status = SatelliteStatus.Active
        },
        new Satellite
        {
            Id = 5,
            Name = "ComSat-9",
            OrbitAltitudeKm = 20200,
            Status = SatelliteStatus.Decommissioned
        },
        new Satellite
        {
            Id = 6,
            Name = "NovaLink",
            OrbitAltitudeKm = 650,
            Status = SatelliteStatus.Active
        },
        new Satellite
        {
            Id = 7,
            Name = "GeoEye",
            OrbitAltitudeKm = 36000,
            Status = SatelliteStatus.Standby
        },
        new Satellite
        {
            Id = 8,
            Name = "PolarScan",
            OrbitAltitudeKm = 850,
            Status = SatelliteStatus.Standby
        },
        new Satellite
        {
            Id = 9,
            Name = "Sentinel-Z",
            OrbitAltitudeKm = 1500,
            Status = SatelliteStatus.Active
        },
        new Satellite
        {
            Id = 10,
            Name = "AuroraNet",
            OrbitAltitudeKm = 28000,
            Status = SatelliteStatus.Standby
        }
    };
    public async Task<IEnumerable<Satellite>> GetAllAsync()
    {
        await Task.Delay(10);
        return _satellites;
    }
    public async Task<Satellite?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        Satellite? satellite = _satellites.FirstOrDefault(s => s.Id == id);
        return satellite;
    }
    public async Task<Satellite> CreateAsync(Satellite satellite)
    {
        await Task.Delay(10);
        satellite.Id = _nextId;
        _nextId++;
        _satellites.Add(satellite);
        return satellite;
    }
    public async Task<Satellite?> UpdateAsync(int id, Satellite satellite)
    {
        Satellite? existing = _satellites.FirstOrDefault(s => s.Id == id);
        if (existing == null)
        {
            return null;
        }
        existing.Status = satellite.Status;
        existing.OrbitAltitudeKm = satellite.OrbitAltitudeKm;
        existing.Name = satellite.Name;
        return existing;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        Satellite? existing = _satellites.FirstOrDefault(s => s.Id == id);
        if (existing == null)
        {
            return false;
        }
        _satellites.Remove(existing);
        return true;
    }
}
