using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Motivos
{
    public class MotivosPagingModel
    {
        public List<Spartane.Core.Domain.Motivos.Motivos> Motivoss { set; get; }
        public int RowCount { set; get; }
    }
}
