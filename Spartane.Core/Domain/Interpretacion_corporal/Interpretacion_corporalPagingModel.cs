using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Interpretacion_corporal
{
    public class Interpretacion_corporalPagingModel
    {
        public List<Spartane.Core.Domain.Interpretacion_corporal.Interpretacion_corporal> Interpretacion_corporals { set; get; }
        public int RowCount { set; get; }
    }
}
