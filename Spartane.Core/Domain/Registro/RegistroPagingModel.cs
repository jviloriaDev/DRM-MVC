using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Registro
{
    public class RegistroPagingModel
    {
        public List<Spartane.Core.Domain.Registro.Registro> Registros { set; get; }
        public int RowCount { set; get; }
    }
}
