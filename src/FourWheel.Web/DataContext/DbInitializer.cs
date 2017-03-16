using FourWheel.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace FourWheel.Web.DataContext
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            FourWheelContext context = applicationBuilder.ApplicationServices.GetRequiredService<FourWheelContext>();

            if (!context.Customers.Any())
            {
                context.Customers.AddRange
                (
                    new Customer { Name = "Daniel", Address = "Adresse 1", Phone = "123", RegisteredCars = new List<RegisteredCar> { new RegisteredCar { Car = new Car { Make = "BMW", Model = "E36", Year = 2000 }, Registration = "AX12345" } } },
                    new Customer { Name = "Thomas", Address = "Adresse 2", Phone = "456", RegisteredCars = new List<RegisteredCar> { new RegisteredCar { Car = new Car { Make = "Ford", Model = "Focus", Year = 2000 }, Registration = "XX12345" } } }
                );
            }

            context.SaveChanges();
        }
    }
}
