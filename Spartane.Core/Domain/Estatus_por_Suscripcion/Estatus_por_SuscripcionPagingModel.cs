using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_por_Suscripcion
{
    public class Estatus_por_SuscripcionPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion> Estatus_por_Suscripcions { set; get; }
        public int RowCount { set; get; }
    }
}
