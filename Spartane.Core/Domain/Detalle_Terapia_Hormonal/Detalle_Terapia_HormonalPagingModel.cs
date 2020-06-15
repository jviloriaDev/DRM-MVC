using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Terapia_Hormonal
{
    public class Detalle_Terapia_HormonalPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> Detalle_Terapia_Hormonals { set; get; }
        public int RowCount { set; get; }
    }
}
