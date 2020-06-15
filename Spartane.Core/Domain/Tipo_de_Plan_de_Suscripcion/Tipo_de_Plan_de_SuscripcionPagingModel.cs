using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion
{
    public class Tipo_de_Plan_de_SuscripcionPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion> Tipo_de_Plan_de_Suscripcions { set; get; }
        public int RowCount { set; get; }
    }
}
