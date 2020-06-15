using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Business_Rule_Creation
{
    public class Business_Rule_CreationPagingModel
    {
        public List<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> Business_Rule_Creations { set; get; }
        public int RowCount { set; get; }
    }
}
