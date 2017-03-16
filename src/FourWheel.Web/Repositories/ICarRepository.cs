using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }
        Car this[string make, string model, int year] { get; }
    }
}
