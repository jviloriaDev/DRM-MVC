using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Interpretacion_IMC
{
    public class Interpretacion_IMCPagingModel
    {
        public List<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> Interpretacion_IMCs { set; get; }
        public int RowCount { set; get; }
    }
}
