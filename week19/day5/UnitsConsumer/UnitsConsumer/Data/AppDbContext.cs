using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsConsumer.Models;

namespace UnitsConsumer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<UavModels> Uavs { get; set; }
        public DbSet<HostileUnits> HostileUnits { get; set; }
        public DbSet<Tracks> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<HostileUnits>()
                .HasOne(e => e.UavModel)
                .WithMany(u => u.Hostiles)
                .HasForeignKey(e => e.model_id)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Tracks>()
                .HasOne(t => t.hostile)
                .WithMany(h => h.Tracks)
                .HasForeignKey(t => t.unit_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
