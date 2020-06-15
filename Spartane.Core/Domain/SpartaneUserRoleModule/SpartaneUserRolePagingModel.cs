using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneUserRoleModule
{
   public class SpartaneUserRolePagingModel
    {
        public List<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule> Spartan_Modules { set; get; }
        public int RowCount { set; get; }
    }
}
