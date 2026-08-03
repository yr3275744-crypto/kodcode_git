using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _libraryDbContext.books.ToListAsync();
    }
    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _libraryDbContext.books.FindAsync(id);
    }
    public async Task<Book> CreateAsync(Book book)
    {
        _libraryDbContext.books.Add(book);
        await _libraryDbContext.SaveChangesAsync();
        return book;
    }
    public async Task<bool> UpdateAsync(int id, Book book)
    {
        var existing = await GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        existing.ISBN = book.ISBN;
        existing.Author = book.Author;
        existing.AvailableCopies = book.AvailableCopies;
        existing.PublishedYear = book.PublishedYear;
        existing.Title = book.Title;
        await _libraryDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        _libraryDbContext.books.Remove(existing);
        await _libraryDbContext.SaveChangesAsync();
        return true;
    }
}