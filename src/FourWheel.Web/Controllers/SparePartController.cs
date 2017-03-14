using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Controllers
{
    public class SparePartController : Controller
    {
        ISparePartRepository sparePartRepository;

        public SparePartController(ISparePartRepository sparePartRepository)
        {
            this.sparePartRepository = sparePartRepository;
        }

        public IActionResult Details(int id)
        {
            SparePart sparePart;

            if ((sparePart = sparePartRepository[id]) == null)
            {
                return NotFound();
            }
            return View(sparePart);
        }
    }
}
