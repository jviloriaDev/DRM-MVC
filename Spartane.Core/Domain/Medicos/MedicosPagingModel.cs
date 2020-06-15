using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Medicos
{
    public class MedicosPagingModel
    {
        public List<Spartane.Core.Domain.Medicos.Medicos> Medicoss { set; get; }
        public int RowCount { set; get; }
    }
}
