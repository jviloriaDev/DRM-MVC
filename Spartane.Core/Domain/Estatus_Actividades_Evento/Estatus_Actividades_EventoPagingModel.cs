using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Actividades_Evento
{
    public class Estatus_Actividades_EventoPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> Estatus_Actividades_Eventos { set; get; }
        public int RowCount { set; get; }
    }
}
