using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class RegisteredCar
    {
        public Car Car { get; set; }
        [Key]
        public string Registration { get; set; }
    }
}
