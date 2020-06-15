using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Frecuencia_Sustancias
{
    public class Frecuencia_SustanciasPagingModel
    {
        public List<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> Frecuencia_Sustanciass { set; get; }
        public int RowCount { set; get; }
    }
}
