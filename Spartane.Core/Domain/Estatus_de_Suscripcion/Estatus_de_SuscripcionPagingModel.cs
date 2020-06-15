using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_de_Suscripcion
{
    public class Estatus_de_SuscripcionPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion> Estatus_de_Suscripcions { set; get; }
        public int RowCount { set; get; }
    }
}
