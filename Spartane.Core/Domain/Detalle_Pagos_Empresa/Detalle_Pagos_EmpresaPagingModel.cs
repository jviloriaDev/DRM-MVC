using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Pagos_Empresa
{
    public class Detalle_Pagos_EmpresaPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> Detalle_Pagos_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
