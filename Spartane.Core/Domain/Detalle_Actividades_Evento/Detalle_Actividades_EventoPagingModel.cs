using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Actividades_Evento
{
    public class Detalle_Actividades_EventoPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Actividades_Evento.Detalle_Actividades_Evento> Detalle_Actividades_Eventos { set; get; }
        public int RowCount { set; get; }
    }
}
