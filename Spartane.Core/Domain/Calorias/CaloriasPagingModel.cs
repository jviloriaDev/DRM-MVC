using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Calorias
{
    public class CaloriasPagingModel
    {
        public List<Spartane.Core.Domain.Calorias.Calorias> Caloriass { set; get; }
        public int RowCount { set; get; }
    }
}
