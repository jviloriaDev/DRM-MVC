using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Dashboard_Config_Detail
{
    public class Dashboard_Config_DetailPagingModel
    {
        public List<Spartane.Core.Domain.Dashboard_Config_Detail.Dashboard_Config_Detail> Dashboard_Config_Details { set; get; }
        public int RowCount { set; get; }
    }
}
