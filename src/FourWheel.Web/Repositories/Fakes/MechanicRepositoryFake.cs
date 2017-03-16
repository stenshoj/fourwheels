using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories.Fakes
{
    public class MechanicRepositoryFake : IMechanicRepository
    {
        private List<Mechanic> mechanics = new List<Mechanic>
        {
            new Mechanic { Username = "Hans" },
            new Mechanic { Username = "Troels" }
        };

        public Mechanic this[string username]
        {
            get
            {
                return mechanics.First(m => m.Username.ToUpper() == username.ToUpper());
            }
        }
    }
}
