using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Planes_Alimenticios
{
    public class Planes_AlimenticiosPagingModel
    {
        public List<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> Planes_Alimenticioss { set; get; }
        public int RowCount { set; get; }
    }
}
