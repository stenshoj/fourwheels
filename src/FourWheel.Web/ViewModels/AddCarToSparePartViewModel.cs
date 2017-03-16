using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels
{
    public class AddCarToSparePartViewModel
    {
        public IEnumerable<Car> Cars { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public IDictionary<string, bool> CarsToBeAdded { get; set; }

        public ICollection<CarSparePart> CarSpareParts { get; set; }
        public IEnumerable<Car> CarsBySpareParts { get; internal set; }
        public SparePart SparePart { get; internal set; }
    }
}
