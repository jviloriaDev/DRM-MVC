using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Planes_de_Suscripcion
{
    public class Planes_de_SuscripcionPagingModel
    {
        public List<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion> Planes_de_Suscripcions { set; get; }
        public int RowCount { set; get; }
    }
}
