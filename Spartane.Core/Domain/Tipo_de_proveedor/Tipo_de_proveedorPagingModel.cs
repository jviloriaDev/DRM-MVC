using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_proveedor
{
    public class Tipo_de_proveedorPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_proveedor.Tipo_de_proveedor> Tipo_de_proveedors { set; get; }
        public int RowCount { set; get; }
    }
}
