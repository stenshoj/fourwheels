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
                throw new NotImplementedException();
            }
        }

        public SparePart this[int id]
        {
            get
            {
                return GetSpareParts().Where(sparePart => sparePart.Id == id).First();
            }
        }

        public IEnumerable<SparePart> SpareParts
        {
            get
            {
                return GetSpareParts();
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
            throw new NotImplementedException();
        }

        private IEnumerable<SparePart> GetSpareParts()
        {
            yield return new SparePart { Id = 1, Name = "Engine", Price = 1000 };
            yield return new SparePart { Id = 2, Name = "Rearview mirror", Price = 30 };
            yield return new SparePart { Id = 1, Name = "Windshield", Price = 200 };
            yield return new SparePart { Id = 1, Name = "Cupholder", Price = 10 };
            yield return new SparePart { Id = 1, Name = "Flux capacitor", Price = 10999.95M };
        }
    }
}
