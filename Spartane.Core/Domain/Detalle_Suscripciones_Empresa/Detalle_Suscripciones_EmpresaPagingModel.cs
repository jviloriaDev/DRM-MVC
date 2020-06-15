using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Suscripciones_Empresa
{
    public class Detalle_Suscripciones_EmpresaPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> Detalle_Suscripciones_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
