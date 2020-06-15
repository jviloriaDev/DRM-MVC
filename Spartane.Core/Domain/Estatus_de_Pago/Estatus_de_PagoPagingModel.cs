using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_de_Pago
{
    public class Estatus_de_PagoPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> Estatus_de_Pagos { set; get; }
        public int RowCount { set; get; }
    }
}
