using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Condition;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Conditions_Detail
{
    /// <summary>
    /// Spartan_BR_Conditions_Detail table
    /// </summary>
    public class Spartan_BR_Conditions_Detail: BaseEntity
    {
        public int ConditionsDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Condition_Operator { get; set; }
        public int? First_Operator_Type { get; set; }
        public string First_Operator_Value { get; set; }
        public short? Condition { get; set; }
        public int? Second_Operator_Type { get; set; }
        public string Second_Operator_Value { get; set; }

        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule Business_Rule_Spartan_Business_Rule { get; set; }
        [ForeignKey("Condition_Operator")]
        public virtual Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator Condition_Operator_Spartan_BR_Condition_Operator { get; set; }
        [ForeignKey("First_Operator_Type")]
        public virtual Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type First_Operator_Type_Spartan_BR_Operator_Type { get; set; }
        [ForeignKey("Condition")]
        public virtual Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition Condition_Spartan_BR_Condition { get; set; }
        [ForeignKey("Second_Operator_Type")]
        public virtual Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type Second_Operator_Type_Spartan_BR_Operator_Type { get; set; }

    }
}

