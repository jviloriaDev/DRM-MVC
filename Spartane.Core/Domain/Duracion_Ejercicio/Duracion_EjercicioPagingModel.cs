using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Duracion_Ejercicio
{
    public class Duracion_EjercicioPagingModel
    {
        public List<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> Duracion_Ejercicios { set; get; }
        public int RowCount { set; get; }
    }
}
