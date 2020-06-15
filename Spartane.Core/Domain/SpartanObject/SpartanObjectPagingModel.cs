using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartanObject
{
    public class SpartanObjectPagingModel
    {
        public List<Spartane.Core.Domain.SpartanObject.SpartanObject> SpartanObjects { set; get; }
        public int RowCount { set; get; }
    }
}
