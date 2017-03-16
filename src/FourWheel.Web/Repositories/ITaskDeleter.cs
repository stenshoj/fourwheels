using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface ITaskDeleter
    {
        bool Delete(WorkTask task);
    }
}