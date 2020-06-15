using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Business_Rule_Creation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Testing
{
    /// <summary>
    /// Spartan_BR_Testing table
    /// </summary>
    public class Spartan_BR_Testing: BaseEntity
    {
        public int Key_Testing { get; set; }
        public int? User_that_reviewed { get; set; }
        public string Acceptance_Critera { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_Reason { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public string Evidence_URL { get; set; }
        public int? Business_Rule { get; set; }

        [ForeignKey("User_that_reviewed")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User_that_reviewed_Spartan_User { get; set; }
        [ForeignKey("Rejection_Reason")]
        public virtual Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason Rejection_Reason_Spartan_BR_Rejection_Reason { get; set; }
        [ForeignKey("Evidence")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Evidence_Spartane_File { get; set; }
        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation Business_Rule_Business_Rule_Creation { get; set; }

    }
}

