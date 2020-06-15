using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Categorias_de_platillos
{
    public class Categorias_de_platillosPagingModel
    {
        public List<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> Categorias_de_platilloss { set; get; }
        public int RowCount { set; get; }
    }
}
