using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Platillos
{
    public class Detalle_PlatillosPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> Detalle_Platilloss { set; get; }
        public int RowCount { set; get; }
    }
}
