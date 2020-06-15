using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Profesiones
{
    public class ProfesionesPagingModel
    {
        public List<Spartane.Core.Domain.Profesiones.Profesiones> Profesioness { set; get; }
        public int RowCount { set; get; }
    }
}
