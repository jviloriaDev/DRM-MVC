using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Titulos_Personales
{
    public class Titulos_PersonalesPagingModel
    {
        public List<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> Titulos_Personaless { set; get; }
        public int RowCount { set; get; }
    }
}
