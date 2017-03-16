using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class CarSparePart
    {
        public int Id { get; set; }
        public virtual Car Car { get; set; }
        public virtual SparePart SparePart { get; set; }
    }
}
