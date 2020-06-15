using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Registro_en_Evento
{
    public class Registro_en_EventoPagingModel
    {
        public List<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> Registro_en_Eventos { set; get; }
        public int RowCount { set; get; }
    }
}
