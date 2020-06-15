using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Especialidades
{
    public class EspecialidadesPagingModel
    {
        public List<Spartane.Core.Domain.Especialidades.Especialidades> Especialidadess { set; get; }
        public int RowCount { set; get; }
    }
}
