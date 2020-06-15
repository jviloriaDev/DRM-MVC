using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus_Padecimiento
{
    public class Estatus_PadecimientoPagingModel
    {
        public List<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> Estatus_Padecimientos { set; get; }
        public int RowCount { set; get; }
    }
}
