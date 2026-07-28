using Microsoft.AspNetCore.Mvc;
using VehicleFleetRegistryAPI.Models;
using VehicleFleetRegistryAPI.Repositories;

namespace VehicleFleetRegistryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    IVehicleRepository _vehicleRepository;

    public VehiclesController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetAll()
    {
        var all = _vehicleRepository.GetAll();
        return Ok(all);
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> GetById(int id)
    {
        var vehicle = _vehicleRepository.GetById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpGet("regisration/{regNumber}")]
    public ActionResult<Vehicle> GetByRegistrationNumber(string regNumber)
    {
        var vehicle = _vehicleRepository.GetByRegistrationNumber(regNumber);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpGet("status/{status}")]
    public ActionResult<IEnumerable<Vehicle>> GetByStatus(string status)
    {
        var vehicles = _vehicleRepository.GetByStatus(status);
        return Ok(vehicles);
    }

    [HttpGet("type/{type}")]
    public ActionResult<IEnumerable<Vehicle>> GetByType(string type)
    {
        var vehicles = _vehicleRepository.GetByType(type);
        return Ok(vehicles);
    }

    [HttpPost]
    public ActionResult<Vehicle> Create(Vehicle vehicle)
    {
        var newVehicle = _vehicleRepository.Create(vehicle);
        return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Vehicle vehicle)
    {
        var existiting = _vehicleRepository.Update(id, vehicle);
        if (existiting == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool success = _vehicleRepository.Delete(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
