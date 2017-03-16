namespace FourWheel.Web.Models
{
    public class WorkTaskSparePart
    {
        public int Id { get; set; }
        public SparePart SparePart { get; set; }
        public WorkTask Task { get; set; }
    }
}