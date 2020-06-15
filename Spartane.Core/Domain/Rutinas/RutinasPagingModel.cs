using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Rutinas
{
    public class RutinasPagingModel
    {
        public List<Spartane.Core.Domain.Rutinas.Rutinas> Rutinass { set; get; }
        public int RowCount { set; get; }
    }
}
