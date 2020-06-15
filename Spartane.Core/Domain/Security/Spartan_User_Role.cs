using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Security
{
    public class Spartan_User_Role
    {
        public int User_RoleId { get; set; }
        public string Description { get; set; }
        public Spartan_User_Role_Status Status { get; set; }
    }
}
