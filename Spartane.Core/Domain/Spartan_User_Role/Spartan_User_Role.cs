using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User_Role_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_User_Role
{
    /// <summary>
    /// Spartan_User_Role table
    /// </summary>
    public class Spartan_User_Role: BaseEntity
    {
        public int User_Role_Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status Status_Spartan_User_Role_Status { get; set; }

    }
}

