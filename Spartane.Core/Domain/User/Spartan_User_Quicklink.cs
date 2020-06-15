using Spartane.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class Spartan_User_Quicklink
    {
        public int Quicklink { get; set; }
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User { get; set; }
        public virtual Spartane.Core.Domain.Spartan_Object.Spartan_Object Object { get; set; }
        public int Order_Shown { get; set; }
        public virtual Spartan_Method_Type Method_Type { get; set; }
        public string Description { get; set; }
        public int AtributeId { get; set; }
        public virtual Spartan_Control_Type Control_Type { get; set; }
    }
}
