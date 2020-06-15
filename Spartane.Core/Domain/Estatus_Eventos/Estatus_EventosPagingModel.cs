using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Eventos
{
    public class Estatus_EventosPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> Estatus_Eventoss { set; get; }
        public int RowCount { set; get; }
    }
}
