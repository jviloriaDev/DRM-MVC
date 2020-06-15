using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Spartan_User_Historical_Password
{
    public class Spartan_User_Historical_PasswordPagingModel
    {
        public List<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> Spartan_User_Historical_Passwords { set; get; }
        public int RowCount { set; get; }
    }
}
