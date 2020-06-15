using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Contactos_Empresa
{
    public class Detalle_Contactos_EmpresaPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> Detalle_Contactos_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
