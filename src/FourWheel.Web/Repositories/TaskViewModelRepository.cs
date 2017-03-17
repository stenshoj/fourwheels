using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourWheel.Web.Models;
using FourWheel.Web.ViewModels;
using FourWheel.Web.Repositories.RegisteredCarRepository;

namespace FourWheel.Web.Repositories
{
    public class TaskViewModelRepository : ITaskViewModelRepository
    {
        private IRegisteredCarRepository registeredCarRepository;
        private IMechanicRepository mechanicRepository;

        public IEnumerable<WorkTaskViewModel> Tasks
        {
            get
            {
                return registeredCarRepository.RegisteredCars.Select(MapToViewModel);
            }
        }

        public WorkTaskViewModel this[int id]
        {
            get
            {
                return MapToViewModel(registeredCarRepository.RegisteredCars.First(car => car.Task.Id == id));
            }
        }

        public TaskViewModelRepository(IRegisteredCarRepository registeredCarRepository, IMechanicRepository mechanicRepository)
        {
            this.registeredCarRepository = registeredCarRepository;
            this.mechanicRepository = mechanicRepository;
        }

        public void Create(WorkTaskViewModel viewModel)
        {
            var registeredCar = registeredCarRepository[viewModel.Registration];
            var mechanic = mechanicRepository[viewModel.MechanicUsername];
            registeredCar.Task = new WorkTask { Description = viewModel.Description, Mechanic = mechanic };
            registeredCarRepository.UpdateRegisteredCar(registeredCar);
        }

        public bool Delete(WorkTaskViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkTaskViewModel viewModel)
        {
            var registeredCar = registeredCarRepository[viewModel.Registration];
            var task = registeredCar.Task;
            var mechanic = mechanicRepository[viewModel.MechanicUsername];
            task.Description = viewModel.Description;
            task.Mechanic = mechanic;
            registeredCarRepository.UpdateRegisteredCar(registeredCar);
        }

        private WorkTaskViewModel MapToViewModel(RegisteredCar registeredCar)
        {
            return new WorkTaskViewModel
            {
                Id = registeredCar.Task.Id,
                Description = registeredCar.Task.Description,
                MechanicUsername = registeredCar.Task.Mechanic.Username,
                Registration = registeredCar.Registration
            };
        }
    }
}
