using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
using FourWheel.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FourWheel.Web.Controllers
{
    public class TaskController : Controller
    {
        private ITaskViewModelRepository taskRepository;
        private IMechanicStartViewModelRepository mechanicStartRepository;
        private ITaskManager taskManager;

        public TaskController(ITaskViewModelRepository taskRepository, IMechanicStartViewModelRepository mechanicStartRepository, ITaskManager taskManager)
        {
            this.taskRepository = taskRepository;
            this.mechanicStartRepository = mechanicStartRepository;
            this.taskManager = taskManager;
        }

        public IActionResult Index()
        {
            return View(taskRepository.Tasks);
        }

        public IActionResult Create()
        {
            return View(new WorkTaskViewModel());
        }

        [HttpPost]
        public IActionResult Create(WorkTaskViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Create");
            taskRepository.Create(viewModel);
            return View("Success");
        }

        public IActionResult Edit(int? id)
        {
            if(id.HasValue)
                return View(taskRepository[id.Value]);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(WorkTaskViewModel workTaskViewModel)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index");
            taskRepository.Update(workTaskViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult ActiveTasks()
        {
            return View(mechanicStartRepository.ActiveTasks);
        }

        public IActionResult Start(string username)
        {
            return View(mechanicStartRepository[username]);
        }

        public IActionResult StartTask(int id)
        {
            taskManager.Start(id);
            return RedirectToAction("ActiveTasks");
        }

        public IActionResult Complete(string username)
        {
            return View(mechanicStartRepository.GetActiveForMechanic(username));
        }

        public IActionResult CompleteTask(int id)
        {
            taskManager.Complete(id);
            return RedirectToAction("ActiveTasks");
        }
    }
}
