using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Format;
using Spartane.Core.Domain.Spartan_Format_Permission_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Format_Permissions
{
    /// <summary>
    /// Spartan_Format_Permissions table
    /// </summary>
    public class Spartan_Format_Permissions: BaseEntity
    {
        public int PermissionId { get; set; }
        public int? Format { get; set; }
        public short? Permission_Type { get; set; }
        public bool? Apply { get; set; }
        public int? Spartan_User_Role { get; set; }

        [ForeignKey("Format")]
        public virtual Spartane.Core.Domain.Spartan_Format.Spartan_Format Format_Spartan_Format { get; set; }
        [ForeignKey("Permission_Type")]
        public virtual Spartane.Core.Domain.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type Permission_Type_Spartan_Format_Permission_Type { get; set; }

    }
}

