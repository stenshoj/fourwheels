using System.Collections.Generic;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface ITaskReader
    {
        IEnumerable<WorkTask> Tasks { get; }
        WorkTask this[int id] { get; }
    }
}