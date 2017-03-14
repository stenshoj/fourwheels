using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Model
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        IEnumerable<IRegisteredCar> registeredCars { get; }

        void AddRegisteredCar(IRegisteredCar registeredCar);
        void RemoveRegisteredCar(IRegisteredCar registeredCar);
    }
}
