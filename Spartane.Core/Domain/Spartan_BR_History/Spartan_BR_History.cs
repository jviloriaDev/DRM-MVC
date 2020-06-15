using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Type_History;
using Spartane.Core.Domain.Business_Rule_Creation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_History
{
    /// <summary>
    /// Spartan_BR_History table
    /// </summary>
    public class Spartan_BR_History: BaseEntity
    {
        public int Key_History { get; set; }
        public int? User_logged { get; set; }
        public short? Status { get; set; }
        public DateTime? Change_Date { get; set; }
        public string Hour_Date { get; set; }
        public int? Time_elapsed { get; set; }
        public int? Change_Type { get; set; }
        public string Conditions { get; set; }
        public string Actions_True { get; set; }
        public string Actions_False { get; set; }
        public int? BusinessRule { get; set; }

        [ForeignKey("User_logged")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User_logged_Spartan_User { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_BR_Status.Spartan_BR_Status Status_Spartan_BR_Status { get; set; }
        [ForeignKey("Change_Type")]
        public virtual Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History Change_Type_Spartan_BR_Type_History { get; set; }
        [ForeignKey("BusinessRule")]
        public virtual Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation BusinessRule_Business_Rule_Creation { get; set; }

    }
}

