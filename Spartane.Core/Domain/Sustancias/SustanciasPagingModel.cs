using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Sustancias
{
    public class SustanciasPagingModel
    {
        public List<Spartane.Core.Domain.Sustancias.Sustancias> Sustanciass { set; get; }
        public int RowCount { set; get; }
    }
}
