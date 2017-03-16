using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourWheel.Web.ViewModels.SpareParts;

namespace FourWheel.Web.DataContext
{
    public class FourWheelContext : DbContext
    {
        public FourWheelContext(DbContextOptions<FourWheelContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<CarSparePart> CarSpareParts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(c => new { c.Make, c.Model, c.Year });
        }
        public DbSet<SparePartViewModel> SparePartViewModel { get; set; }
    }
}
