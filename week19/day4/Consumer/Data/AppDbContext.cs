using Consumer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<Call> Calls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Call>()
                .HasOne(c => c.Analyst)
                .WithMany(a => a.Calls)
                .HasForeignKey(c => c.analyst_id)
                .OnDelete(DeleteBehavior.Cascade);

        }
        
    }
}
