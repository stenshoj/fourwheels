using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.DataContext
{
    public class FourWheelContext : DbContext
    {
        
        public DbSet<SparePart> SpareParts { get; set; }
    }
}
