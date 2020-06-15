using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Sexo
{
    public class SexoPagingModel
    {
        public List<Spartane.Core.Domain.Sexo.Sexo> Sexos { set; get; }
        public int RowCount { set; get; }
    }
}
