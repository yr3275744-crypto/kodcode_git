using System.Net.NetworkInformation;
using VehicleFleetRegistryAPI.Models;

namespace VehicleFleetRegistryAPI.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private List<Vehicle> _vehicles = new List<Vehicle>
    {
        new Vehicle
        {
            Id = 1,
            RegistrationNumber = "12345",
            VehicleType = "Sedan",
            Status = VehicleStatus.Available,
            AssignedDriver = "John Smith",
            CurrentLocation = "Tel Aviv",
            Mileage = 45230
        },
        new Vehicle
        {
            Id = 2,
            RegistrationNumber = "67890",
            VehicleType = "SUV",
            Status = VehicleStatus.InUse,
            AssignedDriver = "David Cohen",
            CurrentLocation = "Jerusalem",
            Mileage = 78500
        },
        new Vehicle
        {
            Id = 3,
            RegistrationNumber = "11223",
            VehicleType = "Truck",
            Status = VehicleStatus.Maintenance,
            AssignedDriver = "Michael Levi",
            CurrentLocation = "Haifa",
            Mileage = 156200
        },
        new Vehicle
        {
            Id = 4,
            RegistrationNumber = "44556",
            VehicleType = "Van",
            Status = VehicleStatus.Available,
            AssignedDriver = "Daniel Green",
            CurrentLocation = "Rishon LeZion",
            Mileage = 32100
        },
        new Vehicle
        {
            Id = 5,
            RegistrationNumber = "77889",
            VehicleType = "Pickup Truck",
            Status = VehicleStatus.InUse,
            AssignedDriver = "Eitan Bar",
            CurrentLocation = "Beer Sheva",
            Mileage = 98450
        },
        new Vehicle
        {
            Id = 6,
            RegistrationNumber = "99001",
            VehicleType = "Motorcycle",
            Status = VehicleStatus.Decommissioned,
            AssignedDriver = "Noam Katz",
            CurrentLocation = "Ashdod",
            Mileage = 245000
        },
        new Vehicle
        {
            Id = 7,
            RegistrationNumber = "23456",
            VehicleType = "Minibus",
            Status = VehicleStatus.Maintenance,
            AssignedDriver = "Yossi Ben-David",
            CurrentLocation = "Netanya",
            Mileage = 187600
        },
        new Vehicle
        {
            Id = 8,
            RegistrationNumber = "34567",
            VehicleType = "Electric Car",
            Status = VehicleStatus.Available,
            AssignedDriver = "Avi Rosen",
            CurrentLocation = "Petah Tikva",
            Mileage = 27600
        },
        new Vehicle
        {
            Id = 9,
            RegistrationNumber = "45678",
            VehicleType = "Ambulance",
            Status = VehicleStatus.InUse,
            AssignedDriver = "Moshe Gold",
            CurrentLocation = "Holon",
            Mileage = 112300
        },
        new Vehicle
        {
            Id = 10,
            RegistrationNumber = "56789",
            VehicleType = "Bus",
            Status = VehicleStatus.Available,
            AssignedDriver = "Shimon Weiss",
            CurrentLocation = "Herzliya",
            Mileage = 342800
        }
    };

    private int _nextId = 11;

    public IEnumerable<Vehicle> GetAll()
    {
        return _vehicles;
    }
    public Vehicle? GetById(int id)
    {
        Vehicle? vehicle = _vehicles
            .FirstOrDefault(v => v.Id == id);
        return vehicle;
    }
    public Vehicle? GetByRegistrationNumber(string regNumber)
    {
        Vehicle? vehicle = _vehicles
            .FirstOrDefault(v => v.RegistrationNumber == regNumber);
        return vehicle;
    }
    public IEnumerable<Vehicle> GetByStatus(string status)
    {
        return _vehicles.Where(v => v.Status.ToString() == status);
    }

    public IEnumerable<Vehicle> GetByType(string type)
    {
        return _vehicles.Where(v => v.VehicleType == type);
    }

    public Vehicle Create(Vehicle vehicle)
    {
        vehicle.Id = _nextId;
        _nextId++;
        return vehicle;
    }
    public Vehicle? Update(int id, Vehicle vehicle)
    {
        Vehicle? exsisting = GetById(id);
        if (exsisting == null)
        {
            return null;
        }
        exsisting.RegistrationNumber = vehicle.RegistrationNumber;
        exsisting.VehicleType = vehicle.VehicleType;
        exsisting.Status = vehicle.Status;
        exsisting.AssignedDriver = vehicle.AssignedDriver;
        exsisting.CurrentLocation = vehicle.CurrentLocation; ;
        exsisting.Mileage = vehicle.Mileage;
        return exsisting;
    }
    public bool Delete(int id)
    {
        Vehicle? exsisting = GetById(id);
        if (exsisting == null)
        {
            return false;
        }
        _vehicles.Remove(exsisting);
        return true;
    }

}
