using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.Fakes
{
    public class SparePartRepositoryMock : ISparePartRepository
    {
        public ISparePart this[int id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ISparePart> SpareParts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Create(ISparePart sparePart)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISparePart sparePart)
        {
            throw new NotImplementedException();
        }

        public void Update(ISparePart sparePart)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ISparePart> GetSpareParts()
        {
            yield return new SparePart { Id = 1, Name = "Engine", Price = 1000 };
            yield return new SparePart { Id = 2, Name = "Rearview mirror", Price = 30 };
            yield return new SparePart { Id = 1, Name = "Windshield", Price = 200 };
            yield return new SparePart { Id = 1, Name = "Cupholder", Price = 10 };
            yield return new SparePart { Id = 1, Name = "Flux capacitor", Price = 10999.95M };
        }
    }
}
