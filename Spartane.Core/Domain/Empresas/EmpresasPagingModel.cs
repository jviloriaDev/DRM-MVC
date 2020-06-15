using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Empresas
{
    public class EmpresasPagingModel
    {
        public List<Spartane.Core.Domain.Empresas.Empresas> Empresass { set; get; }
        public int RowCount { set; get; }
    }
}
