using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Paciente
{
    public class Estatus_PacientePagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> Estatus_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
