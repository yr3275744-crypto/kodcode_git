using SensorSiteStatusAPI.Models;

namespace SensorSiteStatusAPI.storage;

public class SitesList
{
    public static List<SensorSite> Sites { get; } =
        [
            new SensorSite(1, "Site A - Main Entrance", "Zone 1", "Active", DateTime.Now),
            new SensorSite(2, "Site B - North Perimeter", "Zone 1", "Active", DateTime.Now.AddMinutes(-5)),
            new SensorSite(3, "Site C - Warehouse East", "Zone 2", "Inactive", DateTime.Now.AddMinutes(-12)),
            new SensorSite(4, "Site D - Warehouse West", "Zone 2", "Active", DateTime.Now.AddMinutes(-2)),
            new SensorSite(5, "Site E - Loading Dock", "Zone 2", "Warning", DateTime.Now.AddMinutes(-1)),
            new SensorSite(6, "Site F - Server Room", "Zone 3", "Active", DateTime.Now),
            new SensorSite(7, "Site G - Rooftop Solar", "Zone 4", "Maintenance", DateTime.Now.AddHours(-1)),
            new SensorSite(8, "Site H - Parking Lot", "Zone 4", "Active", DateTime.Now.AddMinutes(-20)),
            new SensorSite(9, "Site I - Cafeteria", "Zone 5", "Active", DateTime.Now.AddMinutes(-15)),
            new SensorSite(10, "Site J - Executive Office", "Zone 5", "Offline", DateTime.Now.AddHours(-3))
        ];
}
