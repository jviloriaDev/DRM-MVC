using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Examenes_Laboratorio
{
    public class Detalle_Examenes_LaboratorioPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> Detalle_Examenes_Laboratorios { set; get; }
        public int RowCount { set; get; }
    }
}
