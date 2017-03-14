using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.RegisteredCarRepository
{
    public interface IRegisteredCarRepository
    {
        IEnumerable<RegisteredCar> RegisteredCars { get; }

        void CreateRegisteredCar(RegisteredCar registeredCar);

        void DeleteRegisteredCar(RegisteredCar registeredCar);

        RegisteredCar this[string registration] { get; }

        void UpdateRegisteredCar(RegisteredCar registeredCar);
    }
}
