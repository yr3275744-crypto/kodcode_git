using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public class LibraryDbContext : DbContext
{
    //public DbContextOptions<LibraryDbContext> Options{ get; set; }
    public DbSet<Book> books { get; set; }
    public DbSet<Member> members { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
}
