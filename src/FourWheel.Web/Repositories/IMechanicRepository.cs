using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public interface IMechanicRepository
    {
        Mechanic this[string username] { get; }
    }
}