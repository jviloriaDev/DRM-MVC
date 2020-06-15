using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Unidades_de_Medida
{
    public class Unidades_de_MedidaPagingModel
    {
        public List<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> Unidades_de_Medidas { set; get; }
        public int RowCount { set; get; }
    }
}
