using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Common
{
    public class Spartan_Control_Type
    {
        public int Control_TypeId { get; set; }
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User { get; set; }
        public virtual Spartan_Object Object { get; set; }
        public int Order_Shown { get; set; }
    }
}
