using Microsoft.AspNetCore.Mvc;
using UniversityApi.Models;
using UniversityApi.Repositories;
namespace UniversityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repository;
    public StudentsController(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll()
    {
        var students = await _repository.GetAllAsync();
        return Ok(students);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetById(int id)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student == null)
            return NotFound();
        return Ok(student);
    }
    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student student)
    {
        var created = await _repository.CreateAsync(student);
        return CreatedAtAction(nameof(GetById), new { id = created.Id },

        created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        var success = await _repository.UpdateAsync(id, student);
        if (!success)
            return NotFound();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _repository.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}