using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Bancos
{
    public class BancosPagingModel
    {
        public List<Spartane.Core.Domain.Bancos.Bancos> Bancoss { set; get; }
        public int RowCount { set; get; }
    }
}
