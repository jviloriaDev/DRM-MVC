using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Spartan_User_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_User
{
    /// <summary>
    /// Spartan_User table
    /// </summary>
    public class Spartan_User: BaseEntity
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public int? Image { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public virtual Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role Role_Spartan_User_Role { get; set; }
        [ForeignKey("Image")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status Status_Spartan_User_Status { get; set; }

    }
}

