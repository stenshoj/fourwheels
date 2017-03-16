using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.DataContext;
using FourWheel.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FourWheel.Web.Repositories
{
    public class MechanicStartViewModelRepository : IMechanicStartViewModelRepository
    {
        private FourWheelContext context;

        public MechanicStartViewModel ActiveTasks
        {
            get
            {
                return new MechanicStartViewModel
                {
                    WorkTasks = context.Tasks.Include(task => task.Mechanic)
                    .Where(task => task.IsStarted && !task.IsCompleted)
                    .ToList()
                };
            }
        }

        public MechanicStartViewModel this[string username]
        {
            get
            {
                return new MechanicStartViewModel
                {
                    WorkTasks = context.Tasks.Include(task => task.Mechanic)
                    .Where(task => task.Mechanic.Username.ToUpper() == username.ToUpper())
                    .Where(task => !task.IsStarted && !task.IsCompleted)
                    .ToList()
                };
            }
        }

        public MechanicStartViewModelRepository(FourWheelContext context)
        {
            this.context = context;
        }

        public MechanicStartViewModel GetActiveForMechanic(string username)
        {
            return new MechanicStartViewModel
            {
                WorkTasks = context.Tasks.Include(task => task.Mechanic)
                .Where(task => task.Mechanic.Username.ToUpper() == username.ToUpper())
                .Where(task => task.IsStarted && !task.IsCompleted)
                .ToList()
            };
        }
    }
}
