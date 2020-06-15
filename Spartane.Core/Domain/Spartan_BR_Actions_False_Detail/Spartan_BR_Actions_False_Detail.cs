using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Result;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Actions_False_Detail
{
    /// <summary>
    /// Spartan_BR_Actions_False_Detail table
    /// </summary>
    public class Spartan_BR_Actions_False_Detail: BaseEntity
    {
        public int ActionsFalseDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Action_Classification { get; set; }
        public int? Action { get; set; }
        public short? Action_Result { get; set; }
        public string Parameter_1 { get; set; }
        public string Parameter_2 { get; set; }
        public string Parameter_3 { get; set; }
        public string Parameter_4 { get; set; }
        public string Parameter_5 { get; set; }

        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule Business_Rule_Spartan_Business_Rule { get; set; }
        [ForeignKey("Action_Classification")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification Action_Classification_Spartan_BR_Action_Classification { get; set; }
        [ForeignKey("Action")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action Action_Spartan_BR_Action { get; set; }
        [ForeignKey("Action_Result")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result Action_Result_Spartan_BR_Action_Result { get; set; }

    }
}

