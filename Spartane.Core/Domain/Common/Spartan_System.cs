using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Common
{
    public class Spartan_System
    {
        public int SystemId { get; set; }
        public string Version { get; set; }
        public virtual Spartan_File SystemImage { get; set; }
        public virtual Spartan_File CustomerImage { get; set; }
        public virtual Spartan_File DeveloperImage { get; set; }
    }
}
