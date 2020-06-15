using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estatus
{
    public class EstatusPagingModel
    {
        public List<Spartane.Core.Domain.Estatus.Estatus> Estatuss { set; get; }
        public int RowCount { set; get; }
    }
}
