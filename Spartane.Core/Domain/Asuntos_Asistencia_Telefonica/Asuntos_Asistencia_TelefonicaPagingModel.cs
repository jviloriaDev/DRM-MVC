using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Asuntos_Asistencia_Telefonica
{
    public class Asuntos_Asistencia_TelefonicaPagingModel
    {
        public List<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> Asuntos_Asistencia_Telefonicas { set; get; }
        public int RowCount { set; get; }
    }
}
