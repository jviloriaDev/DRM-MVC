using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Template_Dashboard_Detail
{
    public class Template_Dashboard_DetailPagingModel
    {
        public List<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail> Template_Dashboard_Details { set; get; }
        public int RowCount { set; get; }
    }
}
