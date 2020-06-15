using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.TTArchivos
{
    public class TTArchivosPagingModel
    {
        public List<Spartane.Core.Domain.TTArchivos.TTArchivos> TTArchivoss { set; get; }
        public int RowCount { set; get; }
    }
}
