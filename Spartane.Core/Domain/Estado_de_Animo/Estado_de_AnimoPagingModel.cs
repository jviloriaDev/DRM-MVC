using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Estado_de_Animo
{
    public class Estado_de_AnimoPagingModel
    {
        public List<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> Estado_de_Animos { set; get; }
        public int RowCount { set; get; }
    }
}
