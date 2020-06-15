using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_User_RoleModel
    {
        [Required]
        public int User_Role_Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }

    }
}

