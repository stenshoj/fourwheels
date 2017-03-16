using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface IRegisteredCarRepository
    {
        IEnumerable<RegisteredCar> Cars { get; }
        RegisteredCar this[string registration] { get; }
        void Update(RegisteredCar registeredCar);
    }
}
