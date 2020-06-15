using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Padecimientos
{
    public class PadecimientosPagingModel
    {
        public List<Spartane.Core.Domain.Padecimientos.Padecimientos> Padecimientoss { set; get; }
        public int RowCount { set; get; }
    }
}
