using FourWheel.Data.CarRepository;
using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
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
        private readonly ISparePartRepository sparePartRepo;
        private CarViewModel carModel = new CarViewModel();
        private AddCarToSparePartViewModel addCarToSparePartViewModel = new AddCarToSparePartViewModel();

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

        public IActionResult CarsBySparePart(int id)
        {
            var sparePart = sparePartRepo[id];
            carModel.CarsBySpareParts = carRepo.CarsBySparePart(sparePart);
            return View(carModel);
        }

        //public IActionResult AddToSparePart(int id)
        //{
        //    var sparePart = sparePartRepo[id];
        //    addCarToSparePartViewModel.SparePart = sparePart;
        //    foreach(Car car in carRepo.Cars)
        //    {
        //        addCarToSparePartViewModel.CarsToBeAdded.Add(car.Make + '/' + car.Model + '/' + car.Year, false);
        //    }
        //    return View(addCarToSparePartViewModel);
        //}

        //[HttpPost]
        //public IActionResult AddToSparePart(AddCarToSparePartViewModel addCarToSparePartViewModel)
        //{
        //    var sparePart = addCarToSparePartViewModel.SparePart;
        //    var list = addCarToSparePartViewModel.CarsToBeAdded.Where(entry => entry.Value == true).Select(e => e.Key);
        //    foreach(var carToBeAdded in list)
        //    {
        //        sparePart.CarSpareParts.Add(new CarSparePart
        //        {
        //            Car = carToBeAdded,
        //            SparePart = sparePart
        //        });
        //    }
        //    return RedirectToAction("Index", "SparePart");
        //}

        public IActionResult AddToSparePart()
        {
            var sparePart = new SparePart { Name = "Motor", Price = 100};
            addCarToSparePartViewModel.CarsToBeAdded = new Dictionary<string, bool>();
            addCarToSparePartViewModel.SparePart = sparePart;
            foreach (Car car in carRepo.Cars)
            {
                addCarToSparePartViewModel.CarsToBeAdded.Add(car.Make + '/' + car.Model + '/' + car.Year, false);
            }
            return View(addCarToSparePartViewModel);
        }

        [HttpPost]
        public IActionResult AddToSparePart(AddCarToSparePartViewModel addCarToSparePartViewModel)
        {
            var sparePart = addCarToSparePartViewModel.SparePart;
            var list = addCarToSparePartViewModel.CarsToBeAdded.Where(entry => entry.Value).Select(e => e.Key);
            foreach (var carToBeAdded in list)
            {
                var arguments = carToBeAdded.Split('/');
                sparePart.CarSpareParts.Add(new CarSparePart
                {
                    Car = carRepo[arguments[0], arguments[1], Int32.Parse(arguments[2])],
                    SparePart = sparePart
                });
            }
            return RedirectToAction("Index", "SparePart");
        }
    }
}
