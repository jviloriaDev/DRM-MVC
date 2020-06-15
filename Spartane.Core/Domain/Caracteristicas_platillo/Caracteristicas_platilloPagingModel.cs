using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Caracteristicas_platillo
{
    public class Caracteristicas_platilloPagingModel
    {
        public List<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> Caracteristicas_platillos { set; get; }
        public int RowCount { set; get; }
    }
}
