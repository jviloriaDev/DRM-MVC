using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Eventos
{
    public class EventosPagingModel
    {
        public List<Spartane.Core.Domain.Eventos.Eventos> Eventoss { set; get; }
        public int RowCount { set; get; }
    }
}
