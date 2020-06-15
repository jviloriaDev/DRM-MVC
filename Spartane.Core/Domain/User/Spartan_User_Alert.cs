using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class Spartan_User_Alert
    {
        public int User_AlertId { get; set; }
        public Spartane.Core.Domain.Spartan_User.Spartan_User User { get; set; }
        public Spartan_User_Alert_Type Alert_Type { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual Spartan_User_Alert_Status Status { get; set; }
    }
}
