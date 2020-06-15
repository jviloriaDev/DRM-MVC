using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipos_de_Contrato
{
    public class Tipos_de_ContratoPagingModel
    {
        public List<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato> Tipos_de_Contratos { set; get; }
        public int RowCount { set; get; }
    }
}
