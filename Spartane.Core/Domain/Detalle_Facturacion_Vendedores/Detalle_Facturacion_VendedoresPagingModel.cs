using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Facturacion_Vendedores
{
    public class Detalle_Facturacion_VendedoresPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> Detalle_Facturacion_Vendedoress { set; get; }
        public int RowCount { set; get; }
    }
}
