using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Parentesco
{
    public class ParentescoPagingModel
    {
        public List<Spartane.Core.Domain.Parentesco.Parentesco> Parentescos { set; get; }
        public int RowCount { set; get; }
    }
}
