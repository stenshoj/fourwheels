using FourWheel.Web.Models;
using System.Collections.Generic;

namespace FourWheel.Data.CarRepository
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }

        IEnumerable<Car> CarsBySparePart(SparePart sparePart);

        void CreateCar(Car car);

        void DeleteCar(Car car);

        Car this[string make, string model, int year] { get; }
    }
}
