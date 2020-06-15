using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_de_Padecimientos
{
    public class Detalle_de_PadecimientosPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_de_Padecimientos.Detalle_de_Padecimientos> Detalle_de_Padecimientoss { set; get; }
        public int RowCount { set; get; }
    }
}
