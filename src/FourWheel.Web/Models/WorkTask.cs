using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class WorkTask
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Hours
        {
            get
            {
                return StartTime - EndTime;
            }
        }

        public ICollection<WorkTaskSparePart> SpareParts { get; set; }

        public void Complete()
        {
            EndTime = DateTime.Now;
        }

        public void Start()
        {
            StartTime = DateTime.Now;
        }
    }

}
