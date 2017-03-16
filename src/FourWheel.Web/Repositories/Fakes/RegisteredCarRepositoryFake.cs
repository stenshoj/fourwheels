using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories.Fakes
{
    public class RegisteredCarRepositoryFake : IRegisteredCarRepository
    {
        private List<RegisteredCar> cars = new List<RegisteredCar>
        {
            new RegisteredCar { Car = new Car { Make = "Ford", Model = "Focus", Year = 1989 }, Registration = "XX12312", Task = new WorkTask { Description = "Fix pls", Id = 1, Mechanic = new Mechanic { Username = "Hans" } } },
            new RegisteredCar { Car = new Car { Make = "BMW", Model = "M5", Year = 2010 }, Registration = "XD1337", Task = new WorkTask { Description = "PLS!! FIX!!", Id = 2, Mechanic = new Mechanic { Username = "Troels" } } }
        };

        public RegisteredCar this[string registration]
        {
            get
            {
                return cars.First(car => car.Registration.ToUpper() == registration.ToUpper());
            }
        }

        public IEnumerable<RegisteredCar> Cars
        {
            get
            {
                return cars;
            }
        }

        public void Update(RegisteredCar registeredCar)
        {
            var car = this[registeredCar.Registration];
            car.Car = registeredCar.Car;
            car.Task = registeredCar.Task;
        }
    }
}
