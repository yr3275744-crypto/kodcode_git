using TasksApi.Models;

namespace TasksApi.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        IEnumerable<TaskItem> GetByStatus(StatusEnum status);
        TaskItem Add(TaskItem item);
        bool CompleteTask(int id);
    }
}
