using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Repositories;

namespace FourWheel.Web.Models
{
    public class TaskManager : ITaskManager
    {
        private ITaskRepository taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Start(int id)
        {
            var task = taskRepository[id];
            task.Start();
            taskRepository.Update(task);
        }

        public void Complete(int id)
        {
            var task = taskRepository[id];
            task.Complete();
            taskRepository.Update(task);
        }
    }
}
