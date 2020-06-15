using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Datos_Bancarios_Especialistas
{
    public class Datos_Bancarios_EspecialistasPagingModel
    {
        public List<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> Datos_Bancarios_Especialistass { set; get; }
        public int RowCount { set; get; }
    }
}
