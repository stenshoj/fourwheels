using FourWheel.Web.ViewModels;

namespace FourWheel.Web.Repositories
{
    public interface IMechanicStartViewModelRepository
    {
        MechanicStartViewModel this[string username] { get; }

        MechanicStartViewModel ActiveTasks { get; }

        MechanicStartViewModel GetActiveForMechanic(string username);
    }
}