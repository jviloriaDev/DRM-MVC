using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Planes_Alimenticios
{
    public class Detalle_Planes_AlimenticiosPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios> Detalle_Planes_Alimenticioss { set; get; }
        public int RowCount { set; get; }
    }
}
