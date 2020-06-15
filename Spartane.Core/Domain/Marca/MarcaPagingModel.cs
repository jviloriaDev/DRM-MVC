using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Marca
{
    public class MarcaPagingModel
    {
        public List<Spartane.Core.Domain.Marca.Marca> Marcas { set; get; }
        public int RowCount { set; get; }
    }
}
