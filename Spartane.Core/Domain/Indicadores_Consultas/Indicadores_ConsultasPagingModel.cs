using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Indicadores_Consultas
{
    public class Indicadores_ConsultasPagingModel
    {
        public List<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> Indicadores_Consultass { set; get; }
        public int RowCount { set; get; }
    }
}
