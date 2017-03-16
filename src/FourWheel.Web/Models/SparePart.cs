using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class SparePart
    {
        public ICollection<CarSparePart> CarSpareParts { get; set; }

        public IEnumerable<Car> Cars { get; }

        public int Id { get; set; }

        public bool IsInStock { get; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; }

        public void AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void AddQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void SubtractQuantity(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
