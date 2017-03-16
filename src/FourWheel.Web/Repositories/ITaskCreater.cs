using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface ITaskCreater
    {
        void Create(WorkTask task);
    }
}