using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento
{
    public class Detalle_Registro_en_Actividad_EventoPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> Detalle_Registro_en_Actividad_Eventos { set; get; }
        public int RowCount { set; get; }
    }
}
