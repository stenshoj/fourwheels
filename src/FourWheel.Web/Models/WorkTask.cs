using FourWheel.Web.Models;
using FourWheel.Web.Repositories;
using System.Collections.Generic;

namespace FourWheel.Web.Models
{
    public class WorkTask
    {
        public int Id { get; set; }
        public ICollection<WorkTaskSparePart> WorkTaskSpareParts { get; set; }
        public RegisteredCar RegisteredCar { get; set; }
    }
}