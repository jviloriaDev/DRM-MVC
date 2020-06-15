using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Frecuencia_Ejercicio
{
    public class Frecuencia_EjercicioPagingModel
    {
        public List<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> Frecuencia_Ejercicios { set; get; }
        public int RowCount { set; get; }
    }
}
