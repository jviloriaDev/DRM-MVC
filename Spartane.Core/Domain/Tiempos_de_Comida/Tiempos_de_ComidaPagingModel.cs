using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tiempos_de_Comida
{
    public class Tiempos_de_ComidaPagingModel
    {
        public List<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> Tiempos_de_Comidas { set; get; }
        public int RowCount { set; get; }
    }
}
