using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public interface ICar
    {
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
    }
}
