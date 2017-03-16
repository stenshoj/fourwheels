using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels.SpareParts
{
    public class SparePartViewModel
    {
        private bool isInStock;
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsInStock
        {
            get
            {
                return this.Quantity > 0;
            }
            set
            {
                this.isInStock = value;
            }
        }

        public bool IsToBeAdded { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
