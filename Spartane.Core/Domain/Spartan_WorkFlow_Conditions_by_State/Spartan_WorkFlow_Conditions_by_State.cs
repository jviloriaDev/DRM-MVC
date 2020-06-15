using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition;
using Spartane.Core.Domain.Spartan_WorkFlow_Operator;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Conditions_by_State
{
    /// <summary>
    /// Spartan_WorkFlow_Conditions_by_State table
    /// </summary>
    public class Spartan_WorkFlow_Conditions_by_State: BaseEntity
    {
        public int? Spartan_WorkFlow { get; set; }
        public int Conditions_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Condition_Operator { get; set; }
        public int? Attribute { get; set; }
        public short? Condition { get; set; }
        public short? Operator { get; set; }
        public string Operator_Value { get; set; }
        public short? Priority { get; set; }

        [ForeignKey("Spartan_WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow Spartan_WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases Phase_Spartan_WorkFlow_Phases { get; set; }
        [ForeignKey("State")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_State.Spartan_WorkFlow_State State_Spartan_WorkFlow_State { get; set; }
        [ForeignKey("Condition_Operator")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator Condition_Operator_Spartan_WorkFlow_Condition_Operator { get; set; }
        [ForeignKey("Attribute")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata Attribute_Spartan_Metadata { get; set; }
        [ForeignKey("Condition")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition Condition_Spartan_WorkFlow_Condition { get; set; }
        [ForeignKey("Operator")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator Operator_Spartan_WorkFlow_Operator { get; set; }

    }
}

