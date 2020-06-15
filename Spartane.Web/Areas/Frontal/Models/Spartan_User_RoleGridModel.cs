using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_User_RoleGridModel
    {
        public int User_Role_Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
        
    }
}

