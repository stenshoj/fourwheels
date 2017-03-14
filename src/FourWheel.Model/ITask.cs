using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Model
{
    public interface ITask
    {
        int Id { get; set; }
        string Description { get; set; }
        IRegisteredCar registeredCar { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        ISparePart SparePart { get; set; }
        DateTime Hours { get; }

        void Start();
        void Complete();
        void AddSparePart(ISparePart sparePart);
        void RemoveSparePart(ISparePart sparePart);
    }
}
