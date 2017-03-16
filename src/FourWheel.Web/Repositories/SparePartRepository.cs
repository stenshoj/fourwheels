using FourWheel.Web.DataContext;
using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public class SparePartRepository : ISparePartRepository
    {
        private FourWheelContext context;
        public SparePartRepository(FourWheelContext context)
        {
            this.context = context;
        }
        public IEnumerable<SparePart> this[Car car]
        {
            get
            {
                return from sparePart in context.SpareParts
                       from carSparePart in sparePart.CarSpareParts
                       where carSparePart.Car.Make.ToUpper() == car.Make.ToUpper() && carSparePart.Car.Model.ToUpper() == car.Model.ToUpper() && carSparePart.Car.Year == car.Year
                       select carSparePart.SparePart;
            }
        }

        public SparePart this[int id]
        {
            get
            {
                return context.SpareParts.Where(sparePart => sparePart.Id == id).First();
                //return context.SpareParts.Include(sparePart => sparePart.Cars).Where(sparePart => sparePart.Id == id).First();
            }
        }

        public IEnumerable<SparePart> SpareParts
        {
            get
            {
                return context.SpareParts;
                //return context.SpareParts.Include(sparePart => sparePart.Cars);
            }
        }

        public void Create(SparePart sparePart)
        {
            context.SpareParts.Add(sparePart);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SparePart sparePart)
        {
            var part = context.SpareParts.First(s => s.Id == sparePart.Id);

            part.Name = sparePart.Name;
            part.Price = sparePart.Price;
        }
    }
}
