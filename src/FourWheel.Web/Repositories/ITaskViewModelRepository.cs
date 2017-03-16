using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourWheel.Web.ViewModels;

namespace FourWheel.Web.Repositories
{
    public interface ITaskViewModelRepository
    {
        IEnumerable<WorkTaskViewModel> Tasks { get; }
        WorkTaskViewModel this[int id] { get; }
        void Create(WorkTaskViewModel viewModel);
        void Update(WorkTaskViewModel viewModel);
        bool Delete(WorkTaskViewModel viewModel);
    }
}
