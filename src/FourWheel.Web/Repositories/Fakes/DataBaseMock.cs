using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.Fakes
{
    public static class DataBaseMock
    {


        public static IEnumerable<SparePart> GetSpareParts()
        {
            yield return new SparePart { Id = 1, Name = "Engine", Price = 1000, Quantity = 1 };
            yield return new SparePart { Id = 2, Name = "Rearview mirror", Price = 30, Quantity = 1 };
            yield return new SparePart { Id = 3, Name = "Windshield", Price = 200, Quantity = 1 };
            yield return new SparePart { Id = 4, Name = "Cupholder", Price = 10, Quantity = 1 };
            yield return new SparePart { Id = 5, Name = "Flux capacitor", Price = 10999.95M, Quantity = 1 };
        }

        public static IEnumerable<WorkTask> GetWorkTasks()
        {
            WorkTask task;
            task = new WorkTask { Id = 1, RegisteredCar = new RegisteredCar { Car = new Car { Make = "Ford", Model = "Fiesta", Year = 1989 } } };
            task.WorkTaskSpareParts = GetTaskSpareParts(task).ToList();
            task.RegisteredCar.Car.CarSpareParts = GetCarSpareParts(task.RegisteredCar.Car).ToList();
            yield return task;
            task = new WorkTask { Id = 2, RegisteredCar = new RegisteredCar { Car = new Car { Make = "Dodge", Model = "Viper", Year = 2010 } } };
            task.WorkTaskSpareParts = GetTaskSpareParts(task).ToList();
            task.RegisteredCar.Car.CarSpareParts = GetCarSpareParts(task.RegisteredCar.Car).ToList();
            yield return task;
            task = new WorkTask { Id = 3, RegisteredCar = new RegisteredCar { Car = new Car { Make = "Toyota", Model = "Supra", Year = 2000 } } };
            task.WorkTaskSpareParts = GetTaskSpareParts(task).ToList();
            task.RegisteredCar.Car.CarSpareParts = GetCarSpareParts(task.RegisteredCar.Car).ToList();
            yield return task;
        }

        public static IEnumerable<Car> GetCars()
        {
            Car car;
            car = new Car { Make = "Ford", Model = "Fiesta", Year = 1989 };
            car.CarSpareParts = GetCarSpareParts(car).ToList();
            yield return car;
            car = new Car { Make = "Dodge", Model = "Viper", Year = 2010 };
            car.CarSpareParts = GetCarSpareParts(car).ToList();
            yield return car;
            car = new Car { Make = "Toyota", Model = "Supra", Year = 2000 };
            car.CarSpareParts = GetCarSpareParts(car).ToList();
            yield return car;
        }

        public static IEnumerable<CarSparePart> GetCarSpareParts(Car car)
        {
            yield return new CarSparePart { SparePart = new SparePart { Id = 1, Name = "Engine", Price = 1000, Quantity = 1 }, Car = car };
            yield return new CarSparePart { SparePart = new SparePart { Id = 2, Name = "Rearview mirror", Price = 30, Quantity = 1 }, Car = car };
            yield return new CarSparePart { SparePart = new SparePart { Id = 3, Name = "Windshield", Price = 200, Quantity = 1 }, Car = car };
            yield return new CarSparePart { SparePart = new SparePart { Id = 4, Name = "Cupholder", Price = 10, Quantity = 1 }, Car = car };
            yield return new CarSparePart { SparePart = new SparePart { Id = 5, Name = "Flux capacitor", Price = 10999.95M, Quantity = 1 }, Car = car };
        }

        public static IEnumerable<WorkTaskSparePart> GetTaskSpareParts(WorkTask task)
        {
            yield return new WorkTaskSparePart { SparePart = new SparePart { Id = 1, Name = "Engine", Price = 1000, Quantity = 1 }, WorkTask = task };
            yield return new WorkTaskSparePart { SparePart = new SparePart { Id = 2, Name = "Rearview mirror", Price = 30, Quantity = 1 }, WorkTask = task };
            yield return new WorkTaskSparePart { SparePart = new SparePart { Id = 3, Name = "Windshield", Price = 200, Quantity = 1 }, WorkTask = task };
            yield return new WorkTaskSparePart { SparePart = new SparePart { Id = 4, Name = "Cupholder", Price = 10, Quantity = 1 }, WorkTask = task };
            yield return new WorkTaskSparePart { SparePart = new SparePart { Id = 5, Name = "Flux capacitor", Price = 10999.95M, Quantity = 1 }, WorkTask = task };
        }


    }
}
