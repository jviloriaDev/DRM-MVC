using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Equipamiento_para_Ejercicios
{
    public class Equipamiento_para_EjerciciosPagingModel
    {
        public List<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> Equipamiento_para_Ejercicioss { set; get; }
        public int RowCount { set; get; }
    }
}
