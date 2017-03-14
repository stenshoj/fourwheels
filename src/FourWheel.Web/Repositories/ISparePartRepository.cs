using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public interface ISparePartRepository
    {
        IEnumerable<ISparePart> SpareParts { get; }
        ISparePart this[int id] { get; }
        void Create(ISparePart sparePart);
        void Update(ISparePart sparePart);
        void Delete(ISparePart sparePart);
    }
}
