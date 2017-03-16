namespace FourWheel.Web.Models
{
    public class WorkTaskSparePart
    {
        public int Id { get; set; }
        public WorkTask WorkTask { get; set; }
        public SparePart SparePart { get; set; }
    }
}