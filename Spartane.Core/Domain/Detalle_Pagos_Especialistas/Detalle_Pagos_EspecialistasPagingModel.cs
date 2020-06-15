using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Pagos_Especialistas
{
    public class Detalle_Pagos_EspecialistasPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> Detalle_Pagos_Especialistass { set; get; }
        public int RowCount { set; get; }
    }
}
