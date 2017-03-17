
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class WorkTaskSparePart
    {
        public int Id { get; set; }
        public SparePart SparePart { get; set; }
        public WorkTask Task { get; set; }
    }
}
