using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories
{
    public interface ITaskRepository : ITaskCreater, ITaskReader, ITaskUpdater, ITaskDeleter
    {

    }
}
