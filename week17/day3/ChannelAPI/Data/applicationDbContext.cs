using ChannelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChannelAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<Channel> channels { get; set; }
    public DbSet<Message> messages { get; set; }
}
