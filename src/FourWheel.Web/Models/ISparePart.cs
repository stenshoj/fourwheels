using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public interface ISparePart
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; }
        bool IsInStock { get; }
        IEnumerable<ICar> Cars { get; }

        void AddCar(ICar car);
        void RemoveCar(ICar car);
        void AddQuantity(int quantity);
        void SubtractQuantity(int quantity);
    }
}
