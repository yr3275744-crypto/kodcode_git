using Microsoft.AspNetCore.Mvc;
using TasksApi.Models;
using TasksApi.Repositories;

namespace TasksApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("status/{status}")]
        public ActionResult<IEnumerable<TaskItem>> GetByStatus(string status)
        {
            StatusEnum statusEnum;
            if (!Enum.TryParse<StatusEnum>(status, true, out statusEnum))
            {
                return BadRequest("Invalid status");
            }
            var result = _repository.GetByStatus(statusEnum);
            return Ok(result);
        }
        [HttpPost]
        public StatusCodeResult Add(TaskItem fromClient)
        {
            var result = _repository.Add(fromClient);
            return StatusCode(201);
        }
        [HttpPut("{id}/complete")]
        public IActionResult CompleteTask(int id)
        {
            var result = _repository.CompleteTask(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost("{id}/archive")]
        public async Task<IActionResult> Archive()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));
            await Task.Delay(5000, cts.Token); // ינסה לחכות 5 שניות, אבל יבוטל אחרי 100ms
            return Ok();
        }
    }
}
