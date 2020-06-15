using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Suplementos
{
    public class SuplementosPagingModel
    {
        public List<Spartane.Core.Domain.Suplementos.Suplementos> Suplementoss { set; get; }
        public int RowCount { set; get; }
    }
}
