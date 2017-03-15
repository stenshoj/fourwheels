using FourWheel.Data.CarRepository;
using FourWheel.Web.Models;
using FourWheel.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository carRepo;
        private CarViewModel carModel = new CarViewModel();

        public CarController(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
            carModel.Cars = carRepo.Cars
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ThenBy(c => c.Year);
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Car Index";
            return View(carModel);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Car Create";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel carViewModel)
        {
            var car = new Car {
                Make = carViewModel.Make,
                Model = carViewModel.Model,
                Year = carViewModel.Year
            };

            carRepo.CreateCar(car);
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string make, string model, int year)
        {
            var car = carRepo[make, model, year];
            carRepo.DeleteCar(car);
            return RedirectToAction("Index");
        }

        public IActionResult CarsBySparePart(SparePart sparePart)
        {
            carModel.CarsBySpareParts = carRepo.CarsBySparePart(sparePart);
            return View(carModel);
        }
    }
}
