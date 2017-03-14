using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels.SpareParts
{
    public class SparePartViewModel
    {
        public IEnumerable<Car> Cars { get; }

        public int Id { get; set; }

        public bool IsInStock { get; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; }
    }
}
