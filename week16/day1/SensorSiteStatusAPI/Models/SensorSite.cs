namespace SensorSiteStatusAPI.Models;

public class SensorSite
{
    public int Id { get; set; }
    public string SiteName { get; set; }
    public string Zone { get; set; }
    public string Status { get; set; }
    public DateTime Time { get; set; }
    public SensorSite(
        int id,
        string siteName,
        string zone,
        string status,
        DateTime time)
    {
        Id = id;
        SiteName = siteName;
        Zone = zone;
        Status = status;
        Time = time;
    }

}