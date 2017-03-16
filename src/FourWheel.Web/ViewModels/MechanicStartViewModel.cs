using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.ViewModels
{
    public class MechanicStartViewModel
    {
        public IEnumerable<WorkTask> WorkTasks { get; set; }
    }
}
