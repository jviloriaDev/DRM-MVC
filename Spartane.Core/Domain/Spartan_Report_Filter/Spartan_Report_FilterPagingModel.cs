using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Report_Filter
{
    public class Spartan_Report_FilterPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Report_Filter.Spartan_Report_Filter> Spartan_Report_Filters { set; get; }
        public int RowCount { set; get; }
    }
}
