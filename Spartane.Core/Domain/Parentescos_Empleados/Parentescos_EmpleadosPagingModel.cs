using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Parentescos_Empleados
{
    public class Parentescos_EmpleadosPagingModel
    {
        public List<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> Parentescos_Empleadoss { set; get; }
        public int RowCount { set; get; }
    }
}
