using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
namespace UniversityApi.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;
    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }
    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }
    public async Task<Student> CreateAsync(Student student)
    {
        student.EnrolledAt = DateTime.UtcNow;
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }
    public async Task<bool> UpdateAsync(int id, Student student)
    {
        var existing = await _context.Students.FindAsync(id);
        if (existing == null)
            return false;
        existing.FullName = student.FullName;
        existing.Email = student.Email;
        existing.StudentNumber = student.StudentNumber;
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return false;
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}