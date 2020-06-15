using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Regimenes_Fiscales
{
    public class Regimenes_FiscalesPagingModel
    {
        public List<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> Regimenes_Fiscaless { set; get; }
        public int RowCount { set; get; }
    }
}
