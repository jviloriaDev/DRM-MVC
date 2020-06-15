using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Complexity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Business_Rule_Creation
{
    /// <summary>
    /// Business_Rule_Creation table
    /// </summary>
    public class Business_Rule_Creation: BaseEntity
    {
        public int Key_Business_Rule_Creation { get; set; }
        public int? User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public DateTime? Last_Updated_Date { get; set; }
        public string Last_Updated_Hour { get; set; }
        public int? Time_that_took { get; set; }
        public string Name { get; set; }
        public int? Documentation { get; set; }
        public string Documentation_URL { get; set; }
        public short? Status { get; set; }
        public int? Complexity { get; set; }
        public int? Object { get; set; }
        public int? Attribute { get; set; }
        public bool? AttributeGrid { get; set; }
        public string Implementation_Code { get; set; }

        [ForeignKey("User")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User_Spartan_User { get; set; }
        [ForeignKey("Documentation")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Documentation_Spartane_File { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_BR_Status.Spartan_BR_Status Status_Spartan_BR_Status { get; set; }
        [ForeignKey("Complexity")]
        public virtual Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity Complexity_Spartan_BR_Complexity { get; set; }

    }
}

