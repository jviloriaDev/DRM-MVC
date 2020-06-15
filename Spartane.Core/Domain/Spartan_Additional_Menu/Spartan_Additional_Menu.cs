using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_Additional_Menu
{
    public class Spartan_Additional_Menu
    {
        public int idMenu { get; set; }
        public string MenuName { get; set; }
        public int? ParentMenu { get; set; }
        public string OptionMenu { get; set; }
        public string OptionPath { get; set; }
    }
}
