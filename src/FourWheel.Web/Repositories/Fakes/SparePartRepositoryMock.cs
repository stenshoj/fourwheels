using FourWheel.Web.DataContext;
using FourWheel.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.Fakes
{
    public class SparePartRepositoryMock : ISparePartRepository
    {
        public IEnumerable<SparePart> this[Car car]
        {
            get
            {
                return car.CarSpareParts.Select(carSparePart => carSparePart.SparePart);
            }
        }

        public SparePart this[int id]
        {
            get
            {
                return DataBaseMock.GetSpareParts().Where(sparePart => sparePart.Id == id).First();
            }
        }

        public IEnumerable<SparePart> SpareParts
        {
            get
            {
                return DataBaseMock.GetSpareParts();
            }
        }

        public void Create(SparePart sparePart)
        {
        }

        public void Delete(int id)
        {
        }

        public void Update(SparePart sparePart)
        {
        }
    }
}
