using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Dieta
{
    public class Tipo_de_DietaPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Dieta.Tipo_de_Dieta> Tipo_de_Dietas { set; get; }
        public int RowCount { set; get; }
    }
}
