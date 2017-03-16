using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface ITaskUpdater
    {
        void Update(WorkTask task);
    }
}