using FourWheel.Web.DataContext;
using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public class SparePartRepository
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
                       from compatibleCar in sparePart.Cars
                       where compatibleCar.Make.ToUpper() == car.Make.ToUpper() && compatibleCar.Model.ToUpper() == car.Model.ToUpper() && compatibleCar.Year == car.Year
                       select sparePart;
            }
        }

        public SparePart this[int id]
        {
            get
            {
                using (var context = new FourWheelContext())
                {
                    return context.SpareParts.Where(sparePart => sparePart.Id == id).First();
                    //return context.SpareParts.Include(sparePart => sparePart.Cars).Where(sparePart => sparePart.Id == id).First();
                }
            }
        }

        public IEnumerable<SparePart> SpareParts
        {
            get
            {
                using (var context = new FourWheelContext())
                {
                    return context.SpareParts;
                    //return context.SpareParts.Include(sparePart => sparePart.Cars);
                }
            }
        }

        public void Create(SparePart sparePart)
        {
            throw new NotImplementedException();
        }

        public void Delete(SparePart sparePart)
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
