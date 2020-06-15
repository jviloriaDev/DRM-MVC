using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Indicadores_Laboratorio
{
    public class Indicadores_LaboratorioPagingModel
    {
        public List<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> Indicadores_Laboratorios { set; get; }
        public int RowCount { set; get; }
    }
}
