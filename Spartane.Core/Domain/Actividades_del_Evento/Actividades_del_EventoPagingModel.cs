using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Actividades_del_Evento
{
    public class Actividades_del_EventoPagingModel
    {
        public List<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> Actividades_del_Eventos { set; get; }
        public int RowCount { set; get; }
    }
}
