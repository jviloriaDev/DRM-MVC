using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Registro_de_Asistencia_Telefonica
{
    public class Registro_de_Asistencia_TelefonicaPagingModel
    {
        public List<Spartane.Core.Domain.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> Registro_de_Asistencia_Telefonicas { set; get; }
        public int RowCount { set; get; }
    }
}
