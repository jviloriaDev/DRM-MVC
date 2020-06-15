using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Especialistas_Pacientes
{
    public class Detalle_Especialistas_PacientesPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> Detalle_Especialistas_Pacientess { set; get; }
        public int RowCount { set; get; }
    }
}
