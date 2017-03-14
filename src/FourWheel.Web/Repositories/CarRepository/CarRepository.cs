using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;
using FourWheel.Web.DataContext;

namespace FourWheel.Data.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly FourWheelContext fourWheelContext;

        public CarRepository(FourWheelContext fourWheelContext)
        {
            this.fourWheelContext = fourWheelContext;
        }

        public Car this[string make, string model, int year]
        {
            get
            {
                return fourWheelContext.Cars.First(car => car.Make.ToUpper() == make.ToUpper() && car.Model.ToUpper() == model.ToUpper() && car.Year == year);
            }
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return fourWheelContext.Cars;
            }
        }

        public void CreateCar(Car car)
        {
            fourWheelContext.Add(car);
            fourWheelContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            fourWheelContext.Remove(car);
            fourWheelContext.SaveChanges();
        }
    }
}
