using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Suscripciones_Paciente
{
    public class Detalle_Suscripciones_PacientePagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente> Detalle_Suscripciones_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
