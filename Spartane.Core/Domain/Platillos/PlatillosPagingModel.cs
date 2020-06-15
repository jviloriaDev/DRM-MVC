using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Platillos
{
    public class PlatillosPagingModel
    {
        public List<Spartane.Core.Domain.Platillos.Platillos> Platilloss { set; get; }
        public int RowCount { set; get; }
    }
}
