using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourWheel.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FourWheel.Web.DataContext
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<FourWheelContext>();
            if(!context.RegisteredCars.Any())
            {
                var task = new WorkTask { Description = "Fix", WorkTaskSpareParts = new List<WorkTaskSparePart>() };
                var mechanic = new Mechanic { Username = "hans", Tasks = new List<WorkTask> { task } };
                context.Mechanics.Add(mechanic);
                context.SaveChanges();
                context.RegisteredCars.Add(new RegisteredCar
                {
                    Car = new Car { Make = "Ford", Model = "Focus", Year = 1999, CarSpareParts = new List<CarSparePart>() },
                    Registration = "XD1337",
                    Task = task
                });
                context.SaveChanges();
            }
        }
    }
}
