using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estado_Civil
{
    public class Estado_CivilPagingModel
    {
        public List<Spartane.Core.Domain.Estado_Civil.Estado_Civil> Estado_Civils { set; get; }
        public int RowCount { set; get; }
    }
}
