using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class Mechanic
    {
        public string Username { get; set; }
        public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>();
    }
}
