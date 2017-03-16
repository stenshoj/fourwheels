using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels.SpareParts
{
    public class SparePartToCarViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public IEnumerable<SparePartViewModel> SparePartViewModels { get; set; }
    }
}
