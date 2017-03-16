using FourWheel.Data.CarRepository;
using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
using FourWheel.Web.Repositories.RegisteredCarRepository;
using FourWheel.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Controllers
{
    public class RegisteredCarController : Controller
    {
        private readonly ICarRepository carRepo;
        private readonly IRegisteredCarRepository regCarRepo;
        private readonly ICustomerRepository customerRepo;
        private RegisteredCarViewModel registeredCarViewModel;

        public RegisteredCarController(ICarRepository carRepo, IRegisteredCarRepository regCarRepo, ICustomerRepository customerRepo)
        {
            this.carRepo = carRepo;
            this.regCarRepo = regCarRepo;
            this.customerRepo = customerRepo;
        }

        public IActionResult Edit(string registration, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            registeredCarViewModel.Car = regCarRepo[registration].Car;
            registeredCarViewModel.Registration = registration;
            return View(registeredCarViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RegisteredCarViewModel registeredCarViewModel)
        {
            var car = new Car();
            car.Make = registeredCarViewModel.Car.Make;
            car.Model = registeredCarViewModel.Car.Model;
            car.Year = registeredCarViewModel.Car.Year;
            var registeredCar = regCarRepo[registeredCarViewModel.Registration];
            registeredCar.Car = car;
            regCarRepo.UpdateRegisteredCar(registeredCar);
            if(String.IsNullOrEmpty(ViewBag.ReturnUrl))
                return RedirectToAction("Index", "Car");
            return Redirect(ViewBag.ReturnUrl);
        }

        public IActionResult Delete(string registration, string returnUrl)
        {
            var registeredCar = regCarRepo[registration];
            regCarRepo.DeleteRegisteredCar(registeredCar);
            return Redirect(returnUrl);
        }
    }
}
