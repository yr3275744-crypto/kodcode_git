using VehicleFleetRegistryAPI.Models;

namespace VehicleFleetRegistryAPI.Repositories;

public interface IVehicleRepository
{
    public IEnumerable<Vehicle> GetAll();
    public Vehicle? GetById(int id);
    public Vehicle? GetByRegistrationNumber(string regNumber);
    public IEnumerable<Vehicle> GetByStatus(string status);
    public IEnumerable<Vehicle> GetByType(string type);
    public Vehicle Create(Vehicle vehicle);
    public Vehicle? Update(int id, Vehicle vehicle);
    public bool Delete(int id);
}
