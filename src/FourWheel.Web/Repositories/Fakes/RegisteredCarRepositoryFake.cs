using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.Fakes
{
    public class RegisteredCarRepositoryFake
    {
            private List<RegisteredCar> cars = new List<RegisteredCar>
        {
            new RegisteredCar { Car = new Car { Make = "Ford", Model = "Focus", Year = 1989 }, Registration = "XX12312" },
            new RegisteredCar { Car = new Car { Make = "BMW", Model = "M5", Year = 2010 }, Registration = "XD1337" }
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
        }
}
