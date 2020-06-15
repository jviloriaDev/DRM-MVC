using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tiempo_Padecimiento
{
    public class Tiempo_PadecimientoPagingModel
    {
        public List<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> Tiempo_Padecimientos { set; get; }
        public int RowCount { set; get; }
    }
}
