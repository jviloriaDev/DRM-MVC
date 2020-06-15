using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Object
{
    public class Spartan_ObjectPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Object.Spartan_Object> Spartan_Objects { set; get; }
        public int RowCount { set; get; }
    }
}
