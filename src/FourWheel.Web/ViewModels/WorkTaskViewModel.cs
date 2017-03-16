using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.ViewModels
{
    public class WorkTaskViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Registration { get; set; }
        [Required]
        public string MechanicUsername { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
