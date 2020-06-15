using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Report
{
    public class Spartan_ReportPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Report.Spartan_Report> Spartan_Reports { set; get; }
        public int RowCount { set; get; }
    }
}
