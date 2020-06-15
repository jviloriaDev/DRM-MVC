using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Horarios_Actividad
{
    public class Detalle_Horarios_ActividadPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> Detalle_Horarios_Actividads { set; get; }
        public int RowCount { set; get; }
    }
}
