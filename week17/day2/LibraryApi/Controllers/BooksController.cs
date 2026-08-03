using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private IBookRepository _bookRepository;
    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllAsync()
    {
        List<Book> result = await _bookRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book?>> GetByIdAsync(int id)
    {
        var result = await _bookRepository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateAsync(Book book)
    {
        try
        {
            var result = await _bookRepository.CreateAsync(book);
            return CreatedAtAction("GetById", new { id = result.Id }, result);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is MySqlException)
            {
                return Conflict(ex.Message);
            }
            else
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, Book book)
    {
        var result = await _bookRepository.UpdateAsync(id, book);
        if (result == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookRepository.DeleteAsync(id);
        if (result == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}