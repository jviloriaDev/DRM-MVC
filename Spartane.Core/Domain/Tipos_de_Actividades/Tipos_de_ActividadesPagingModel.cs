using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipos_de_Actividades
{
    public class Tipos_de_ActividadesPagingModel
    {
        public List<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades> Tipos_de_Actividadess { set; get; }
        public int RowCount { set; get; }
    }
}
