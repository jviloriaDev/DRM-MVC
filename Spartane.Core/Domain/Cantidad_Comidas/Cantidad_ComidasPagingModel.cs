using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Cantidad_Comidas
{
    public class Cantidad_ComidasPagingModel
    {
        public List<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> Cantidad_Comidass { set; get; }
        public int RowCount { set; get; }
    }
}
