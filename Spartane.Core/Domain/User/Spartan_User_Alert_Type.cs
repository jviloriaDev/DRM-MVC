using Spartane.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class Spartan_User_Alert_Type
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Spartan_File Image { get; set; }
    }
}
