using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Ejercicios
{
    public class EjerciciosPagingModel
    {
        public List<Spartane.Core.Domain.Ejercicios.Ejercicios> Ejercicioss { set; get; }
        public int RowCount { set; get; }
    }
}
