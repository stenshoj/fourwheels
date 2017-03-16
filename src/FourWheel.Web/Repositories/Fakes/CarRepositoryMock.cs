using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories.Fakes
{
    public class CarRepositoryMock : ICarRepository
    {
        public Car this[string make, string model, int year]
        {
            get
            {
                return DataBaseMock.GetCars().Where(car => car.Make.ToUpper() == make.ToUpper() && car.Model.ToUpper() == model.ToUpper() && car.Year == year).First();
            }
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return DataBaseMock.GetCars();
            }
        }
    }
}
