using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Titulos_Medicos
{
    public class Detalle_Titulos_MedicosPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> Detalle_Titulos_Medicoss { set; get; }
        public int RowCount { set; get; }
    }
}
