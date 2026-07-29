using Microsoft.AspNetCore.Mvc;
using TelemetryAnalyzerAPI.Models;
using TelemetryAnalyzerAPI.Repositories.Interfaces;

namespace TelemetryAnalyzerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SatellitesController : ControllerBase
{
    private readonly ISatelliteRepository _satelliteRepository;
    public SatellitesController(ISatelliteRepository satelliteRepository)
    {
        _satelliteRepository = satelliteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Satellite>>> GetAllAsync()
    {
        var result = await _satelliteRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Satellite>> GetByIdAsync(int id)
    {
        var satellite = await _satelliteRepository.GetByIdAsync(id);
        if (satellite == null)
        {
            return NotFound();
        }
        return Ok(satellite);
    }
    
    [HttpPost]
    public async Task<ActionResult<Satellite>> CreateSatelliteAsync(Satellite satellite)
    {
        Satellite created = await _satelliteRepository.CreateAsync(satellite);
        return CreatedAtAction("GetById", new { id = created.Id }, created);
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateByIdAsync(int id, Satellite satellite)
    {
        var existing = await _satelliteRepository.UpdateAsync(id, satellite);
        if (existing == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool isDeleted = await _satelliteRepository.DeleteAsync(id);
        if (isDeleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
