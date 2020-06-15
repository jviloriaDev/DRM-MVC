using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Metadata
{
    public class Spartan_MetadataPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> Spartan_Metadatas { set; get; }
        public int RowCount { set; get; }
    }
}
