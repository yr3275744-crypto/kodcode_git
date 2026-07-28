using SmartLockerApi.Models;

namespace SmartLockerApi.Repositories;

public interface ILockerRepository
{
    IEnumerable<Locker> GetAll();
    Locker? GetById(int id);
    Locker? GetByLockerNumber(int lockerNumber);
    IEnumerable<Locker> GetByStatus(string status);
    Locker Create(Locker locker);
    Locker? Update(int id, Locker locker);
    bool Delete(int id);
}
