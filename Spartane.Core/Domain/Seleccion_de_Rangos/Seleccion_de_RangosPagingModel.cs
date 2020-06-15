using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Seleccion_de_Rangos
{
    public class Seleccion_de_RangosPagingModel
    {
        public List<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> Seleccion_de_Rangoss { set; get; }
        public int RowCount { set; get; }
    }
}
