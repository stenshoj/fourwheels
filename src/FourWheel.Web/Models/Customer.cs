using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class Customer
    {
        private List<RegisteredCar> registeredCars = new List<RegisteredCar>();

        public string Address { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public ICollection<RegisteredCar> RegisteredCars { get; set; }
    }
}
