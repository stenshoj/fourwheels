using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<WorkTask> WorkTasks { get; }
        WorkTask this[int id] { get; }
        void Update(WorkTask workTask);
    }
}
