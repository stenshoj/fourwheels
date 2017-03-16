using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class RegisteredCar
    {
        public Car Car { get; set; }

        public string Registration { get; set; }

        public WorkTask Task { get; set; }
    }
}
