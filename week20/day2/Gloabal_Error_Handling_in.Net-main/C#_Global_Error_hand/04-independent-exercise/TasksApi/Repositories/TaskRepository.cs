using TasksApi.Models;

namespace TasksApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Learn C#", Description = "Complete C# basics", status = StatusEnum.completed, CreatedAt = DateTime.Now.AddDays(-5) },
            new TaskItem { Id = 2, Title = "Build API", Description = "Create REST API", status = StatusEnum.pending, CreatedAt = DateTime.Now.AddDays(-2) },
            new TaskItem { Id = 3, Title = "Deploy", Description = "Deploy to production", status = StatusEnum.pending, CreatedAt = DateTime.Now.AddDays(-1) }

        };
        int nextId = 4;
        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }
        public TaskItem? GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<TaskItem> GetByStatus(StatusEnum status)
        {
            return _tasks.Where(t => t.status == status)
                .ToList();
        }
        public TaskItem Add(TaskItem item)
        {
            TaskItem newItem = new TaskItem
            {
                Id = nextId,
                CreatedAt = item.CreatedAt,
                Description = item.Description,
                status = item.status,
                Title = item.Title
            };
            _tasks.Add(newItem);
            nextId++;
            return newItem;
        }
        public bool CompleteTask(int id)
        {
            TaskItem? exist = _tasks.FirstOrDefault(t => t.Id == id);
            if (exist == null)
            {
                return false;
            }
            exist.status = StatusEnum.completed;
            return true;
        }
    }
}
