using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public class SparePartRepository : ISparePartRepository
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
    }
}
