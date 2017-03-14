using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.ViewModels.SpareParts
{
    public class SparePartSearchViewModel
    {
        IEnumerable<SparePart> SpareParts { get; set; }
    }
}
