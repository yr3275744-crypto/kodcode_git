using SmartLockerApi.Models;

namespace SmartLockerApi.Repositories;

public class LockerRepository : ILockerRepository
{
    private readonly List<Locker> _lockers;
    private int _nextId;

    public LockerRepository()
    {
        _nextId = 6;
        _lockers = new List<Locker>
        {
            new Locker
            {
                Id = 1,
                LockerNumber = 101,
                Status = "Available"
            },
            new Locker
            {
                Id = 2,
                LockerNumber = 102,
                Status = "Occupied",
                AssignedTo = "Sgt. Cohen",
                EquipmentType = "Night Vision Goggles",
                AssignedAt = DateTime.UtcNow.AddDays(-2)
            },
            new Locker
            {
                Id = 3,
                LockerNumber = 103,
                Status = "Occupied",
                AssignedTo = "Cpl. Levi",
                EquipmentType = "Radio Equipment",
                AssignedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Locker
            {
                Id = 4,
                LockerNumber = 104,
                Status = "Maintenance"
            },
            new Locker
            {
                Id = 5,
                LockerNumber = 105,
                Status = "Available"
            }
        };
    }
    public IEnumerable<Locker> GetAll()
    {
        return _lockers;
    }
    public Locker? GetById(int id)
    {
        return _lockers.FirstOrDefault(l => l.Id == id);
    }
    public Locker? GetByLockerNumber(int lockerNumber)
    {
        return _lockers.FirstOrDefault(l => l.LockerNumber == lockerNumber);
    }
    public IEnumerable<Locker> GetByStatus(string status)
    {
        return _lockers.Where(l => l.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
    }
    public Locker Create(Locker locker)
    {
        locker.Id = _nextId;
        _nextId++;
        _lockers.Add(locker);
        return locker;
    }
    public Locker? Update(int id, Locker updatedLocker)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return null;
        }
        existing.LockerNumber = updatedLocker.LockerNumber;
        existing.Status = updatedLocker.Status;
        existing.AssignedTo = updatedLocker.AssignedTo;
        existing.EquipmentType = updatedLocker.EquipmentType;
        existing.AssignedAt = updatedLocker.AssignedAt;
        return existing;
    }
    public bool Delete(int id)
    {
        Locker? locker = GetById(id);
        if (locker == null)
        {
            return false;
        }
        _lockers.Remove(locker);
        return true;
    }
}
