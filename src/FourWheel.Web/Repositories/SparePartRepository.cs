using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public class SparePartRepository : ISparePartRepository
    {
        public SparePart this[int id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<SparePart> SpareParts
        {
            get
            {
                throw new NotImplementedException();
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
    }
}
