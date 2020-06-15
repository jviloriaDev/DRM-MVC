using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneObject
{
    public class SpartaneObjectPagingModel
    {
        public List<Spartane.Core.Domain.SpartaneObject.SpartaneObject> Spartan_Objects { set; get; }
        public int RowCount { set; get; }
    }
}
