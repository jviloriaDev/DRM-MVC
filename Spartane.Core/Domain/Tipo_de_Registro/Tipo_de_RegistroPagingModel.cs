using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Registro
{
    public class Tipo_de_RegistroPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> Tipo_de_Registros { set; get; }
        public int RowCount { set; get; }
    }
}
