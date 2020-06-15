using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Aseguradoras
{
    public class AseguradorasPagingModel
    {
        public List<Spartane.Core.Domain.Aseguradoras.Aseguradoras> Aseguradorass { set; get; }
        public int RowCount { set; get; }
    }
}
