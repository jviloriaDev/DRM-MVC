using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Sucursal
{
    public class Tipo_de_SucursalPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> Tipo_de_Sucursals { set; get; }
        public int RowCount { set; get; }
    }
}
