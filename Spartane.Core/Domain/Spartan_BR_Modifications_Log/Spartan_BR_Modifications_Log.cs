using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Business_Rule;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Modifications_Log
{
    /// <summary>
    /// Spartan_BR_Modifications_Log table
    /// </summary>
    public class Spartan_BR_Modifications_Log: BaseEntity
    {
        public int ModificationId { get; set; }
        public int Business_Rule { get; set; }
        public DateTime? Modification_Date { get; set; }
        public string Modification_Hour { get; set; }
        public int? Modification_User { get; set; }
        public string Comments { get; set; }
        public string Implementation_Code { get; set; }

        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule Business_Rule_Spartan_Business_Rule { get; set; }

    }
}

