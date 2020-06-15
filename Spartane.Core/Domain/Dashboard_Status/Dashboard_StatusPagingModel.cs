using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Dashboard_Status
{
    public class Dashboard_StatusPagingModel
    {
        public List<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> Dashboard_Statuss { set; get; }
        public int RowCount { set; get; }
    }
}
