using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Identificaciones_Oficiales
{
    public class Identificaciones_OficialesPagingModel
    {
        public List<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> Identificaciones_Oficialess { set; get; }
        public int RowCount { set; get; }
    }
}
