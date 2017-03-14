using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FourWheel.Web.DataContext
{
    public class FourWheelContext : DbContext
    {
        public FourWheelContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<RegisteredCar> RegisteredCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(c => new { c.Make, c.Model, c.Year });
        }
    }
}
