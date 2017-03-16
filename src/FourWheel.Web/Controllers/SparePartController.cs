using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
using FourWheel.Web.ViewModels.SpareParts;
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
        ICarRepository carRepository;
        ITaskRepository taskRepository;

        public SparePartController(ISparePartRepository sparePartRepository, ICarRepository carRepository, ITaskRepository taskRepository)
        {
            this.sparePartRepository = sparePartRepository;
            this.carRepository = carRepository;
            this.taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            return View(GetViewModels(sparePartRepository.SpareParts));
        }

        public IActionResult Index(string make, string model, int year)
        {
            var car = carRepository[make, model, year];
            return View(GetViewModels(sparePartRepository[car]));
        }

        public IActionResult Details(int id)
        {
            return GetSparePartView(id);
        }

        public IActionResult Create()
        {
            return View(new SparePartViewModel());
        }

        [HttpPost]
        public IActionResult Create(SparePartViewModel viewModel)
        {
            var sparePart = new SparePart();
            if (ModelState.IsValid)
            {
                sparePart.Name = viewModel.Name;
                sparePart.Price = viewModel.Price;
                sparePart.Quantity = viewModel.Quantity;
                sparePartRepository.Create(sparePart);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult Edit(int id)
        {
            return GetSparePartView(id);
        }

        [HttpPost]
        public IActionResult Edit(SparePartViewModel viewModel)
        {
            var sparePart = new SparePart();
            if (ModelState.IsValid)
            {
                sparePart.Id = viewModel.Id;
                sparePart.Name = viewModel.Name;
                sparePart.Price = viewModel.Price;
                sparePart.Quantity = viewModel.Quantity;
                sparePartRepository.Update(sparePart);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                sparePartRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddToCar(string make, string model, int year)
        {
            var viewModel = new SparePartToCarViewModel
            {
                Make = make,
                Model = model,
                Year = year,
                SparePartViewModels = GetViewModels(sparePartRepository.SpareParts)
            };
            var car = carRepository[make, model, year];
            var carSpareParts = sparePartRepository[car];
            foreach (var sparePart in carSpareParts)
            {
                viewModel.SparePartViewModels.Where(vm => vm.Id == sparePart.Id).First().IsToBeAdded = true;
            }
            return View(viewModel);
        }
        
        public IActionResult AddSparePartToCar(int id, string make, string model, int year)
        {
            if (ModelState.IsValid)
            {
                Car car;
                (car = carRepository[make, model, year]).CarSpareParts.Add(
                    new CarSparePart
                    {
                        SparePart = sparePartRepository[id],
                        Car = car
                    });
            }
            return RedirectToAction("Index", "Car");
        }

        public IActionResult AddToTask(int id)
        {
            var task = taskRepository[id];
            var viewModel = new SparePartToTaskViewModel
            {
                TaskId = id,
                SparePartViewModels = new List<SparePartViewModel>(GetViewModels(sparePartRepository[task.RegisteredCar.Car]))
            };
            return View(viewModel);
        }
        
        public IActionResult AddSparePartToTask(int id, int taskId)
        {
            if (ModelState.IsValid)
            {
                WorkTask task;
                (task = taskRepository[taskId]).WorkTaskSpareParts.Add(
                    new WorkTaskSparePart
                    {
                        SparePart = sparePartRepository[id],
                        WorkTask = task
                    });
            }
            return RedirectToAction("Index", "Task");
        }

        private IEnumerable<SparePartViewModel> GetViewModels(IEnumerable<SparePart> spareParts)
        {
            foreach (var sparePart in spareParts)
            {
                yield return GetViewModel(sparePart);
            }
        }

        private SparePartViewModel GetViewModel(SparePart sparePart)
        {
            return new SparePartViewModel { Id = sparePart.Id, Name = sparePart.Name, Price = sparePart.Price, Quantity = sparePart.Quantity };
        }

        private IActionResult GetSparePartView(int id)
        {
            SparePart sparePart;
            if ((sparePart = sparePartRepository[id]) == null)
            {
                return NotFound();
            }
            return View(GetViewModel(sparePart));
        }
    }
}
