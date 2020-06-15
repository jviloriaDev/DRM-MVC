using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Llamadas
{
    public class Estatus_LlamadasPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> Estatus_Llamadass { set; get; }
        public int RowCount { set; get; }
    }
}
