//using FourWheel.Data.CarRepository;
//using FourWheel.Web.Models;
//using FourWheel.Web.Repositories.RegisteredCarRepository;
//using FourWheel.Web.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FourWheel.Web.Controllers
//{
//    public class RegisteredCarController : Controller
//    {
//        private readonly ICarRepository carRepo;
//        private readonly IRegisteredCarRepository regCarRepo;
//        private readonly ICustomerRepository customerRepo;
//        private RegisteredCarViewModel registeredCarViewModel;

//        public RegisteredCarController(ICarRepository carRepo, IRegisteredCarRepository regCarRepo, ICustomerRepository customerRepo)
//        {
//            this.carRepo = carRepo;
//            this.regCarRepo = regCarRepo;
//            this.customerRepo = customerRepo;
//        }

//        public IActionResult Edit(int id)
//        {
//            var customer = customerRepo[id];
//            registeredCarViewModel.Customer = customer;
//            registeredCarViewModel.Car = customer.RegisteredCar.Car;
//            registeredCarViewModel.Registration = customer.RegisteredCar.Registration;
//            return View(registeredCarViewModel);
//        }

//        [HttpPost]
//        public IActionResult Edit(RegisteredCarViewModel registeredCarViewModel)
//        {
//            var registeredCar = new RegisteredCar();
//            registeredCar.Car.Make = registeredCarViewModel.Car.Make;
//            registeredCar.Car.Model = registeredCarViewModel.Car.Model;
//            registeredCar.Car.Year = registeredCarViewModel.Car.Year;
//            var customer = registeredCarViewModel.Customer;
//            customer.RegisteredCar = registeredCar;
//            customerRepo.Update(customer);
//            return RedirectToAction("Index", "Customer");
//        }

//        public IActionResult Delete(int id)
//        {
//            var customer = customerRepo[id];
//            var registeredCar = customer.RegisteredCar;
//            regCarRepo.DeleteRegisteredCar(registeredCar);
//            return View("Index", "Customer");
//        }
//    }
//}
