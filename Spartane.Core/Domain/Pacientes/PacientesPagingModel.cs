using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Pacientes
{
    public class PacientesPagingModel
    {
        public List<Spartane.Core.Domain.Pacientes.Pacientes> Pacientess { set; get; }
        public int RowCount { set; get; }
    }
}
