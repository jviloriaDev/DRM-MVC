using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report_Permission_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Permissions
{
    /// <summary>
    /// Spartan_Report_Permissions table
    /// </summary>
    public class Spartan_Report_Permissions: BaseEntity
    {
        public int ReportPermissionId { get; set; }
        public int? User_Role { get; set; }
        public int? Report { get; set; }
        public short? Permission_Type { get; set; }

        [ForeignKey("Report")]
        public virtual Spartane.Core.Domain.Spartan_Report.Spartan_Report Report_Spartan_Report { get; set; }
        [ForeignKey("Permission_Type")]
        public virtual Spartane.Core.Domain.Spartan_Report_Permission_Type.Spartan_Report_Permission_Type Permission_Type_Spartan_Report_Permission_Type { get; set; }

    }
}

