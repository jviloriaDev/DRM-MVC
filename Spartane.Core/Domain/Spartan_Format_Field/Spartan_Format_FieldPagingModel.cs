using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Format_Field
{
    public class Spartan_Format_FieldPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> Spartan_Format_Fields { set; get; }
        public int RowCount { set; get; }
    }
}
