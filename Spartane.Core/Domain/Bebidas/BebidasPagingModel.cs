using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Bebidas
{
    public class BebidasPagingModel
    {
        public List<Spartane.Core.Domain.Bebidas.Bebidas> Bebidass { set; get; }
        public int RowCount { set; get; }
    }
}
