using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public interface ISparePartRepository
    {
        IEnumerable<SparePart> SpareParts { get; }
        SparePart this[int id] { get; }
        IEnumerable<SparePart> this[Car car] { get; }
        void Create(SparePart sparePart);
        void Update(SparePart sparePart);
        void Delete(SparePart sparePart);
    }
}
