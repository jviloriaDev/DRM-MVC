using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Musculos
{
    public class MusculosPagingModel
    {
        public List<Spartane.Core.Domain.Musculos.Musculos> Musculoss { set; get; }
        public int RowCount { set; get; }
    }
}
