using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class SparePart
    {
        public ICollection<CarSparePart> CarSpareParts { get; set; }

        public int Id { get; set; }

        public bool IsInStock { get; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; }
    }
}
