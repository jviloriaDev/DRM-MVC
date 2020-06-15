using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Data
{
    public partial class DataLayerFieldsBitacora : BaseEntity
    {

        public String Folio { get; set; }
        public int Proceso { get; set; }
    }
}
