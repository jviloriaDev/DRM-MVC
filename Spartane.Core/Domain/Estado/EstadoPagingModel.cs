using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estado
{
    public class EstadoPagingModel
    {
        public List<Spartane.Core.Domain.Estado.Estado> Estados { set; get; }
        public int RowCount { set; get; }
    }
}
