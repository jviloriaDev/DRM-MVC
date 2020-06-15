using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Nivel_de_Intensidad
{
    public class Nivel_de_IntensidadPagingModel
    {
        public List<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> Nivel_de_Intensidads { set; get; }
        public int RowCount { set; get; }
    }
}
