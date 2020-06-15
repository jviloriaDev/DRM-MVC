using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Formas_de_Pago
{
    public class Formas_de_PagoPagingModel
    {
        public List<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> Formas_de_Pagos { set; get; }
        public int RowCount { set; get; }
    }
}
