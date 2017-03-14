using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Model
{
    public interface IRegisteredCar
    {
        ICar Car { get; set; }
        string Registration { get; set; }
    }
}
