using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneFunction
{
    public class SpartaneFunctionPagingModel
    {
        public List<Spartane.Core.Domain.SpartaneFunction.SpartaneFunction> Spartane_Functions { set; get; }
        public int RowCount { set; get; }
    }
}
