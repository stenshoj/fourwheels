using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class WorkTask
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsStarted { get; set; } = false;
        public bool IsCompleted { get; set; } = false;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Mechanic Mechanic { get; set; }

        public TimeSpan Hours
        {
            get
            {
                return StartTime - EndTime;
            }
        }

        public ICollection<WorkTaskSparePart> WorkTaskSpareParts { get; set; } = new List<WorkTaskSparePart>();

        public void Complete()
        {
            EndTime = DateTime.Now;
            IsCompleted = true;
        }

        public void Start()
        {
            StartTime = DateTime.Now;
            IsStarted = true;
        }
    }
}
