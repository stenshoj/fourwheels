using FourWheel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Repositories.Fakes
{
    public class TaskRepositoryMock : ITaskRepository
    {
        public WorkTask this[int id]
        {
            get
            {
                return DataBaseMock.GetWorkTasks().Where(task => task.Id == id).First();
            }
        }

        public IEnumerable<WorkTask> WorkTasks
        {
            get
            {
                return DataBaseMock.GetWorkTasks();
            }
        }

        public void Update(WorkTask workTask)
        {
        }
    }
}
