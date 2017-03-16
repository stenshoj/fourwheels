namespace FourWheel.Web.Models
{
    public interface ITaskManager
    {
        void Start(int id);
        void Complete(int id);
    }
}