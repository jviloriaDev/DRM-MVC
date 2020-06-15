using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_User_Role
{
    public class Spartan_User_RolePagingModel
    {
        public List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> Spartan_User_Roles { set; get; }
        public int RowCount { set; get; }
    }
}
