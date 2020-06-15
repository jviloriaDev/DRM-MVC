using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class Spartan_UserObject
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public int? Image { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
