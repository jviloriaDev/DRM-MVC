using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Contratos_Empresa
{
    public class Detalle_Contratos_EmpresaPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa> Detalle_Contratos_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
