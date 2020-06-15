using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Models
{
    public class ModuleDataViewModel
    {
        public int IdModulo { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
    }
}
