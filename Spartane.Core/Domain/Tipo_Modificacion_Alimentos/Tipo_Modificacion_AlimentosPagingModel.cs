using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_Modificacion_Alimentos
{
    public class Tipo_Modificacion_AlimentosPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> Tipo_Modificacion_Alimentoss { set; get; }
        public int RowCount { set; get; }
    }
}
