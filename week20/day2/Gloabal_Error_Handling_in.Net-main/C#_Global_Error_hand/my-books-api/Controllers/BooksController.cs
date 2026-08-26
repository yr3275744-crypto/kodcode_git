using Microsoft.AspNetCore.Mvc;
using ExceptionHandlingLab.Models;
using ExceptionHandlingLab.Repositories;

namespace ExceptionHandlingLab.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BooksController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {

        var books = _repository.GetAll();
        return Ok(books);

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var book = _repository.GetById(id);
        if (book == null)
            return NotFound($"Book with ID {id} not found");

        return Ok(book);

    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {

        if (string.IsNullOrWhiteSpace(book.Title))
            return BadRequest("Title is required");

        if (string.IsNullOrWhiteSpace(book.Author))
            return BadRequest("Author is required");

        if (book.Year < 1000 || book.Year > DateTime.Now.Year)
            return BadRequest("Invalid year");

        var created = _repository.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            return BadRequest("Title is required");

        if (string.IsNullOrWhiteSpace(book.Author))
            return BadRequest("Author is required");

        var updated = _repository.Update(id, book);
        if (updated == null)
            return NotFound($"Book with ID {id} not found");

        return Ok(updated);
    }
}
