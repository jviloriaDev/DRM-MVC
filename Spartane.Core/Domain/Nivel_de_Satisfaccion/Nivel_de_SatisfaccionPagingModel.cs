using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Nivel_de_Satisfaccion
{
    public class Nivel_de_SatisfaccionPagingModel
    {
        public List<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> Nivel_de_Satisfaccions { set; get; }
        public int RowCount { set; get; }
    }
}
