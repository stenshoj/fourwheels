using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWheel.Web.DataContext;
using FourWheel.Web.Models;

namespace FourWheel.Web.Repositories
{
    public class MechanicRepository : IMechanicRepository
    {
        private FourWheelContext context;

        public Mechanic this[string username]
        {
            get
            {
                return context.Mechanics.First(mechanic => mechanic.Username.ToUpper() == username.ToUpper());
            }
        }

        public MechanicRepository(FourWheelContext context)
        {
            this.context = context;
        }
    }
}
