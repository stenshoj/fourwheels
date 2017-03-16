using System;
using System.Collections.Generic;
using System.Linq;
using FourWheel.Web.DataContext;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private FourWheelContext context;

        public WorkTask this[int id]
        {
            get
            {
                return context.Tasks.First(task => task.Id == id);
            }
        }

        public IEnumerable<WorkTask> Tasks
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TaskRepository(FourWheelContext context)
        {
            this.context = context;
        }

        public void Create(WorkTask task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public bool Delete(WorkTask task)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkTask task)
        {
            var dbTask = this[task.Id];
            dbTask.Description = task.Description;
            dbTask.StartTime = task.StartTime;
            dbTask.EndTime = task.EndTime;
            dbTask.IsStarted = task.IsStarted;
            dbTask.IsCompleted = task.IsCompleted;
            dbTask.Mechanic = task.Mechanic;
            dbTask.WorkTaskSpareParts.Clear();
            foreach(var sparePart in task.WorkTaskSpareParts)
                dbTask.WorkTaskSpareParts.Add(sparePart);
            context.SaveChanges();
        }
    }
}
