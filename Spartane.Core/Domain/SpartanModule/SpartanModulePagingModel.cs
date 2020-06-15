using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartanModule
{
   public class SpartanModulePagingModel
    {
        public List<Spartane.Core.Domain.SpartanModule.SpartanModule> Spartan_Modules { set; get; }

        public int RowCount { set; get; }

    }
}
