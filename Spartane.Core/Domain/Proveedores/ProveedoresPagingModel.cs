using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Proveedores
{
    public class ProveedoresPagingModel
    {
        public List<Spartane.Core.Domain.Proveedores.Proveedores> Proveedoress { set; get; }
        public int RowCount { set; get; }
    }
}
