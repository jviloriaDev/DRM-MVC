using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Resultados_IMC
{
    public class Resultados_IMCPagingModel
    {
        public List<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> Resultados_IMCs { set; get; }
        public int RowCount { set; get; }
    }
}
