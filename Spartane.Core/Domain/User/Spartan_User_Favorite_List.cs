using Spartane.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class Spartan_User_Favorite_List
    {
        public int Favorite_ListId { get; set; }
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User { get; set; }
        public virtual Spartane.Core.Domain.Spartan_Object.Spartan_Object Object { get; set; }
        public int Order_Shown { get; set; }
    }
}
