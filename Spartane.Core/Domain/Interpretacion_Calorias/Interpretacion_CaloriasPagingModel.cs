using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Interpretacion_Calorias
{
    public class Interpretacion_CaloriasPagingModel
    {
        public List<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> Interpretacion_Caloriass { set; get; }
        public int RowCount { set; get; }
    }
}
