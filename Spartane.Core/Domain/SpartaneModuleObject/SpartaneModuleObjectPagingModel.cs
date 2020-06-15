using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneModuleObject
{
    public class SpartaneModuleObjectPagingModel
    {
        public List<Spartane.Core.Domain.SpartaneModuleObject.SpartaneModuleObject> Spartan_Module_Objects { set; get; }
        public int RowCount { set; get; }
    }
}
