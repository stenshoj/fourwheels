using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;
using FourWheel.Web.DataContext;

namespace FourWheel.Web.Repositories.RegisteredCarRepository
{
    public class RegisteredCarRepository : IRegisteredCarRepository
    {
        private readonly FourWheelContext fourWheelContext;

        public RegisteredCarRepository(FourWheelContext fourWheelContext)
        {
            this.fourWheelContext = fourWheelContext;
        }

        public RegisteredCar this[string registration]
        {
            get
            {
                return fourWheelContext.RegisteredCars.First(rc => rc.Registration.ToUpper() == registration.ToUpper());
            }
        }

        public IEnumerable<RegisteredCar> RegisteredCars
        {
            get
            {
                return fourWheelContext.RegisteredCars;
            }
        }

        public void CreateRegisteredCar(RegisteredCar registeredCar)
        {
            fourWheelContext.Add(registeredCar);
            fourWheelContext.SaveChanges();
        }

        public void DeleteRegisteredCar(RegisteredCar registeredCar)
        {
            fourWheelContext.Remove(registeredCar);
            fourWheelContext.SaveChanges();
        }

        public void UpdateRegisteredCar(RegisteredCar registeredCar)
        {
            var originalRegisteredCar = fourWheelContext.RegisteredCars.First(rc => rc.Registration.ToUpper() == registeredCar.Registration.ToUpper());
            originalRegisteredCar.Car = registeredCar.Car;
            originalRegisteredCar.Task = registeredCar.Task;
            fourWheelContext.SaveChanges();
        }
    }
}
