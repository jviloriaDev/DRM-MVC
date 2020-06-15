using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_UserModel
    {
        [Required]
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public string RoleDescription { get; set; }
        public int? Image { get; set; }
        public HttpPostedFileBase ImageFile { set; get; }
        public int ImageRemoveAttachment { set; get; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

