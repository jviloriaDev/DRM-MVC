using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Format_Configuration
{
    public class Spartan_Format_ConfigurationPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> Spartan_Format_Configurations { set; get; }
        public int RowCount { set; get; }
    }
}
