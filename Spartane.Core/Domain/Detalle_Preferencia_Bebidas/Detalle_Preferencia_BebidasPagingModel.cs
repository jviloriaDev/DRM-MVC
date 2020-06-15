using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Preferencia_Bebidas
{
    public class Detalle_Preferencia_BebidasPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> Detalle_Preferencia_Bebidass { set; get; }
        public int RowCount { set; get; }
    }
}
