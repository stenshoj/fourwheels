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
        public DbSet<WorkTask> Tasks { get; set; }
        public DbSet<RegisteredCar> RegisteredCars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarSparePart> CarSpareParts { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }

        public FourWheelContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(c => new { c.Make, c.Model, c.Year });
            modelBuilder.Entity<RegisteredCar>()
                .HasKey(c => c.Registration);
            modelBuilder.Entity<Mechanic>()
                .HasKey(mechanic => mechanic.Username);
        }
    }
}
