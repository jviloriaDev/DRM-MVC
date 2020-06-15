using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipos_de_Especialistas
{
    public class Tipos_de_EspecialistasPagingModel
    {
        public List<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas> Tipos_de_Especialistass { set; get; }
        public int RowCount { set; get; }
    }
}
