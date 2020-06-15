using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_BR_History
{
    public class Spartan_BR_HistoryPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_BR_History.Spartan_BR_History> Spartan_BR_Historys { set; get; }
        public int RowCount { set; get; }
    }
}
