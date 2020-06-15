using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Preferencias_Sal
{
    public class Preferencias_SalPagingModel
    {
        public List<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> Preferencias_Sals { set; get; }
        public int RowCount { set; get; }
    }
}
