using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Facturas
{
    public class Estatus_FacturasPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> Estatus_Facturass { set; get; }
        public int RowCount { set; get; }
    }
}
