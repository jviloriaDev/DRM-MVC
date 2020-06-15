using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa
{
    public class Detalle_Registro_Beneficiarios_EmpresaPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa> Detalle_Registro_Beneficiarios_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
