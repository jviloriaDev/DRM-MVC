using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Pais
{
    public class PaisPagingModel
    {
        public List<Spartane.Core.Domain.Pais.Pais> Paiss { set; get; }
        public int RowCount { set; get; }
    }
}
