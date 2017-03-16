using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels.SpareParts
{
    public class SparePartToTaskViewModel
    {
        public int TaskId { get; set; }
        public IEnumerable<SparePartViewModel> SparePartViewModels { get; set; }
    }
}
