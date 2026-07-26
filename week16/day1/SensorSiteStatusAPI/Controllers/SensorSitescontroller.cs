using Microsoft.AspNetCore.Mvc;
using SensorSiteStatusAPI.Models;
using SensorSiteStatusAPI.storage;

namespace SensorSiteStatusAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorSitesController : ControllerBase
{
    [HttpGet()]
    public ActionResult<IEnumerable<SensorSite>> GetAll()
    {
        return Ok(SitesList.Sites);
    }

    [HttpGet("{id}")]
    public ActionResult<SensorSite> GetById(int id)
    {
        var site = SitesList.Sites.FirstOrDefault(site => site.Id == id);
        if (site == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(site);
        }
    }

    [HttpGet("Search")]
    public ActionResult<IEnumerable<SensorSite>> ByZone([FromQuery] string? zone)
    {
        List<SensorSite> result = new();
        if (!string.IsNullOrEmpty(zone))
        {
            result = SitesList.Sites.Where(site => site.Zone == zone)
                .ToList();
        }
        return Ok(result);
    }
}
